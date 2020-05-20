using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Studentski_dom.Models;

namespace Studentski_dom.Controllers
{
    public class StudentsController : Controller
    {
        private readonly NasContext _context;

        public StudentsController(NasContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var nasContext = _context.Student.Include(s => s.PrijavaStudenta).Include(s => s.Soba);
            return View(await nasContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.PrijavaStudenta)
                .Include(s => s.Soba)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["PrijavaStudentaID"] = new SelectList(_context.PrijavaStudenta, "PrijavaStudentaID", "PrijavaStudentaID");
            ViewData["SobaID"] = new SelectList(_context.Soba, "SobaID", "SobaID");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,SobaID,BrojBonova,PrijavaStudentaID")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PrijavaStudentaID"] = new SelectList(_context.PrijavaStudenta, "PrijavaStudentaID", "PrijavaStudentaID", student.PrijavaStudentaID);
            ViewData["SobaID"] = new SelectList(_context.Soba, "SobaID", "SobaID", student.SobaID);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["PrijavaStudentaID"] = new SelectList(_context.PrijavaStudenta, "PrijavaStudentaID", "PrijavaStudentaID", student.PrijavaStudentaID);
            ViewData["SobaID"] = new SelectList(_context.Soba, "SobaID", "SobaID", student.SobaID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,SobaID,BrojBonova,PrijavaStudentaID")] Student student)
        {
            if (id != student.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentID))
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
            ViewData["PrijavaStudentaID"] = new SelectList(_context.PrijavaStudenta, "PrijavaStudentaID", "PrijavaStudentaID", student.PrijavaStudentaID);
            ViewData["SobaID"] = new SelectList(_context.Soba, "SobaID", "SobaID", student.SobaID);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.PrijavaStudenta)
                .Include(s => s.Soba)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentID == id);
        }
    }
}
