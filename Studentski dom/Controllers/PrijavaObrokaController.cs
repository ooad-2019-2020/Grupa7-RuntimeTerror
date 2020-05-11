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
    public class PrijavaObrokaController : Controller
    {
        private readonly NasContext _context;

        public PrijavaObrokaController(NasContext context)
        {
            _context = context;
        }

        // GET: PrijavaObroka
        public async Task<IActionResult> Index()
        {
            var nasContext = _context.PrijavaObroka.Include(p => p.Student);
            return View(await nasContext.ToListAsync());
        }

        // GET: PrijavaObroka/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prijavaObroka = await _context.PrijavaObroka
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.PrijavaObrokaID == id);
            if (prijavaObroka == null)
            {
                return NotFound();
            }

            return View(prijavaObroka);
        }

        // GET: PrijavaObroka/Create
        public IActionResult Create()
        {
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID");
            return View();
        }

        // POST: PrijavaObroka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrijavaObrokaID,StudentID,Rucak,Vecera,ZaPonijetRucak,ZaPonijetVecera")] PrijavaObroka prijavaObroka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prijavaObroka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", prijavaObroka.StudentID);
            return View(prijavaObroka);
        }

        // GET: PrijavaObroka/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prijavaObroka = await _context.PrijavaObroka.FindAsync(id);
            if (prijavaObroka == null)
            {
                return NotFound();
            }
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", prijavaObroka.StudentID);
            return View(prijavaObroka);
        }

        // POST: PrijavaObroka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrijavaObrokaID,StudentID,Rucak,Vecera,ZaPonijetRucak,ZaPonijetVecera")] PrijavaObroka prijavaObroka)
        {
            if (id != prijavaObroka.PrijavaObrokaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prijavaObroka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrijavaObrokaExists(prijavaObroka.PrijavaObrokaID))
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
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", prijavaObroka.StudentID);
            return View(prijavaObroka);
        }

        // GET: PrijavaObroka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prijavaObroka = await _context.PrijavaObroka
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.PrijavaObrokaID == id);
            if (prijavaObroka == null)
            {
                return NotFound();
            }

            return View(prijavaObroka);
        }

        // POST: PrijavaObroka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prijavaObroka = await _context.PrijavaObroka.FindAsync(id);
            _context.PrijavaObroka.Remove(prijavaObroka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrijavaObrokaExists(int id)
        {
            return _context.PrijavaObroka.Any(e => e.PrijavaObrokaID == id);
        }
    }
}
