using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnApp.Controllers
{
    public class NotesByCasesController : Controller
    {
        private readonly LawyerContext _context;

        public NotesByCasesController(LawyerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            string query = "EXEC [selectNotes]";
            List<NotesByCases> listNotesByCases = _context.NotesByCases.FromSql(query).ToList();
           
            return View( listNotesByCases);
        }
    }
}