using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Studentski_dom.Models;

namespace Studentski_dom.Controllers
{
    public class PrijavaObrokaController : Controller
    {
        private readonly NasContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Korisnik> _userManager;

        public PrijavaObrokaController(NasContext context, IHttpContextAccessor httpContextAccessor, UserManager<Korisnik> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        // GET: PrijavaObroka
        public async Task<IActionResult> Index()
        {

            var user = _httpContextAccessor.HttpContext.User;
            var userFromDatabase = await _userManager.GetUserAsync(user);

            var nasContext = _context.PrijavaObroka.Include(p => p.Student)
                .Where(p => (p.createdByUserId == userFromDatabase.Id
                && p.StudentID == userFromDatabase.StudentId)
                || userFromDatabase.UserName == "uposlenikuprave@gmail.com"
                || userFromDatabase.UserName == "sefkuhinje@gmail.com");

            int brojacRucak = (from row in _context.PrijavaObroka
                               where row.Rucak == true
                               select row).Count();

            ViewBag.brojacRucak = brojacRucak;

            int brojacVecera = (from row in _context.PrijavaObroka
                                where row.Vecera == true
                                select row).Count();

            ViewBag.brojacVecera = brojacVecera;

            int rucakPonijeti = (from row in _context.PrijavaObroka
                                 where row.ZaPonijetRucak == true
                                 select row).Count();

            ViewBag.rucakPonijeti = rucakPonijeti;

            int veceraPonijeti = (from row in _context.PrijavaObroka
                                  where row.ZaPonijetVecera == true
                                  select row).Count();

            ViewBag.veceraPonijeti = veceraPonijeti;
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
        public async Task<IActionResult> CreateAsync()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var userFromDatabase = await _userManager.GetUserAsync(user);

            var nasContext = _context.Student
                .Where(p => p.StudentID == userFromDatabase.StudentId);
            ViewData["StudentID"] = new SelectList(nasContext, "StudentID", "StudentID");

            //    ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID");

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
                var user = _httpContextAccessor.HttpContext.User;
                var userFromDatabase = await _userManager.GetUserAsync(user);
                if (userFromDatabase != null
                    && userFromDatabase.StudentId == prijavaObroka.StudentID)
                    prijavaObroka.createdByUserId = userFromDatabase.Id;

                if (prijavaObroka.Rucak == true && prijavaObroka.ZaPonijetRucak == true) ViewBag.Check = "Ne možete izabrti";

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
        public async Task<IActionResult> Delete()
        {
            var prijavaObroka = (from row in _context.PrijavaObroka select row).First();
            if (prijavaObroka == null)
            {
                return NotFound();
            }

            return View(prijavaObroka);
        }

        // POST: PrijavaObroka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            var brojac = (from row in _context.PrijavaObroka select row).Count();
            if (brojac == 0) return RedirectToAction(nameof(Index));
            for (int i = 0; i < brojac; i++)
            {
                var prijavaObroka = (from row in _context.PrijavaObroka select row).First();
                _context.PrijavaObroka.Remove(prijavaObroka);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }

        private bool PrijavaObrokaExists(int id)
        {
            return _context.PrijavaObroka.Any(e => e.PrijavaObrokaID == id);
        }

    }
}
