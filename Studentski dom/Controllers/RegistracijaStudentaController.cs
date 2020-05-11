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
    public class RegistracijaStudentaController : Controller
    {
        /// <summary>
        /// test
        /// </summary>
        private readonly NasContext _context;

        public RegistracijaStudentaController(NasContext context)
        {
            _context = context;
        }

        // GET: RegistracijaStudenta
        public async Task<IActionResult> Index()
        {
            return View(await _context.PrijavaStudenta.ToListAsync());
        }

        // GET: RegistracijaStudenta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prijavaStudenta = await _context.PrijavaStudenta
                .FirstOrDefaultAsync(m => m.PrijavaStudentaID == id);
            if (prijavaStudenta == null)
            {
                return NotFound();
            }

            return View(prijavaStudenta);
        }

        // GET: RegistracijaStudenta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistracijaStudenta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrijavaStudentaID,ImePrezime,JMBG,AdresaStanovanja,Fakultet,GodinaStudiranja,CiklusStudija,BrojIndeksa,BrojTelefona,Email,Fotografija")] PrijavaStudenta prijavaStudenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prijavaStudenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prijavaStudenta);
        }

        // GET: RegistracijaStudenta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prijavaStudenta = await _context.PrijavaStudenta.FindAsync(id);
            if (prijavaStudenta == null)
            {
                return NotFound();
            }
            return View(prijavaStudenta);
        }

        // POST: RegistracijaStudenta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrijavaStudentaID,ImePrezime,JMBG,AdresaStanovanja,Fakultet,GodinaStudiranja,CiklusStudija,BrojIndeksa,BrojTelefona,Email,Fotografija")] PrijavaStudenta prijavaStudenta)
        {
            if (id != prijavaStudenta.PrijavaStudentaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prijavaStudenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrijavaStudentaExists(prijavaStudenta.PrijavaStudentaID))
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
            return View(prijavaStudenta);
        }

        // GET: RegistracijaStudenta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prijavaStudenta = await _context.PrijavaStudenta
                .FirstOrDefaultAsync(m => m.PrijavaStudentaID == id);
            if (prijavaStudenta == null)
            {
                return NotFound();
            }

            return View(prijavaStudenta);
        }

        // POST: RegistracijaStudenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prijavaStudenta = await _context.PrijavaStudenta.FindAsync(id);
            _context.PrijavaStudenta.Remove(prijavaStudenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrijavaStudentaExists(int id)
        {
            return _context.PrijavaStudenta.Any(e => e.PrijavaStudentaID == id);
        }
    }
}
