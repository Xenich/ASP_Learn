using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using LearnApp.Models;


namespace LearnApp.Controllers
{
    public class CasesController : Controller
    {
        private readonly LawyerContext _context;

        public CasesController(LawyerContext context)
        {
            _context = context;
        }

        // GET: Cases
        public async Task<IActionResult> Index()
        {
            /*
             using (OfficeContext db = new OfficeContext())
            {
                string query = "Select Id From Types Where Name = '" + name + "'";
                int[] res = db.Database.SqlQuery<int>(query).ToArray();
                if (res.Length > 0)
                {
                    MessageBox.Show("Такой тип уже есть");
                    return;
                }

                Type t = new Type() { Name = name };
                db.Types.Add(t);
                db.SaveChanges();
                if (addTypeEvent != null)
                    addTypeEvent();
                MessageBox.Show("Новый тип оборудования добавлен");
            }
             * */

            var lawyerContext = _context.Case.Include(@x => @x.Advokate);
            List<Case> list = lawyerContext.ToList();

            return View(await lawyerContext.ToListAsync());
        }

        // GET: Cases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Case
                .Include(@x => @x.Advokate)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@case == null)
            {
                return NotFound();
            }

            return View(@case);
        }

        // GET: Cases/Create
        public IActionResult Create()
        {
            //ViewData["AdvokateId"] = new SelectList(_context.Advokate, "Id", "Id");
            PopulateAdvokatesDropDownList();
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdvokateId,Info,Date")] Case @case)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@case);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateAdvokatesDropDownList(@case.AdvokateId);
            //ViewData["AdvokateId"] = new SelectList(_context.Advokate, "Id", "Id", @case.AdvokateId);
            return View(@case);
        }


        private void PopulateAdvokatesDropDownList(object selectedAdvokate = null)
        {
            var AdvokatesQuery = from d in _context.Advokate
                                 orderby d.Name
                                 select d;
            ViewBag.AdvokateID = new SelectList(AdvokatesQuery.AsNoTracking(), "Id", "Name", selectedAdvokate);
        }

        // GET: Cases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Case.FindAsync(id);
            if (@case == null)
            {
                return NotFound();
            }
            ViewData["AdvokateId"] = new SelectList(_context.Advokate, "Id", "Id", @case.AdvokateId);
            return View(@case);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdvokateId,Info,Date")] Case @case)
        {
            if (id != @case.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@case);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseExists(@case.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdvokateId"] = new SelectList(_context.Advokate, "Id", "Id", @case.AdvokateId);
            return View(@case);
        }

        // GET: Cases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Case
                .Include(@x => @x.Advokate)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@case == null)
            {
                return NotFound();
            }

            return View(@case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @case = await _context.Case.FindAsync(id);
            _context.Case.Remove(@case);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseExists(int id)
        {
            return _context.Case.Any(e => e.Id == id);
        }
    }
}
