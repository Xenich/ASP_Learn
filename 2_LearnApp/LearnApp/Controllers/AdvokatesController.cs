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
    public class AdvokatesController : Controller
    {
        private readonly LawyerContext _context;

        public AdvokatesController(LawyerContext context)
        {
            _context = context;
        }

        // GET: Advokates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Advokate.ToListAsync());
        }

        // GET: Advokates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advokate = await _context.Advokate
                .Include(a=>a.Case)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advokate == null)
            {
                return NotFound();
            }

            return View(advokate);
        }

        // GET: Advokates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Advokates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Advokate advokate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advokate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(advokate);
        }

        // GET: Advokates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advokate = await _context.Advokate.FindAsync(id);
            if (advokate == null)
            {
                return NotFound();
            }
            return View(advokate);
        }

        // POST: Advokates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Advokate advokate)
        {
            if (id != advokate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advokate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvokateExists(advokate.Id))
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
            return View(advokate);
        }

        // GET: Advokates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advokate = await _context.Advokate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advokate == null)
            {
                return NotFound();
            }

            return View(advokate);
        }

        // POST: Advokates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advokate = await _context.Advokate.FindAsync(id);
            _context.Advokate.Remove(advokate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvokateExists(int id)
        {
            return _context.Advokate.Any(e => e.Id == id);
        }
    }
}
