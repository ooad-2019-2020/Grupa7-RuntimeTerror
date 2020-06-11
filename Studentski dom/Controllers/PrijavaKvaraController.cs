using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Studentski_dom.Models;

namespace Studentski_dom.Controllers
{
    public class PrijavaKvaraController : Controller
    {
        private readonly NasContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Korisnik> _userManager;

        public PrijavaKvaraController(NasContext context, IHttpContextAccessor httpContextAccessor, UserManager<Korisnik> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        // GET: PrijavaKvara
        public async Task<IActionResult> Index()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var userFromDatabase = await _userManager.GetUserAsync(user);

            var nasContext = _context.PrijavaKvara.Include(p => p.Student)
                .Where(p => (p.createdByUserId == userFromDatabase.Id
                && p.StudentID == userFromDatabase.StudentId) 
                || userFromDatabase.UserName == "uposlenikuprave@gmail.com" 
                || userFromDatabase.UserName == "seftehnickogodrzavanja@gmail.com");

            return View(await nasContext.ToListAsync());
        }

        // GET: PrijavaKvara/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prijavaKvara = await _context.PrijavaKvara
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.PrijavaKvaraID == id);
            if (prijavaKvara == null)
            {
                return NotFound();
            }

            return View(prijavaKvara);
        }

        // GET: PrijavaKvara/Create
        public async Task<IActionResult> CreateAsync()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var userFromDatabase = await _userManager.GetUserAsync(user);

            var nasContext = _context.Student
                .Where(p => p.StudentID == userFromDatabase.StudentId);
            ViewData["StudentID"] = new SelectList(nasContext, "StudentID", "StudentID");
            //ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID");
            
            return View();
        }

        // POST: PrijavaKvara/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrijavaKvaraID,StudentID,TipKvara,OpisKvara,VrijemePrijave,VrijemeRjesenja,HitanKvar")] PrijavaKvara prijavaKvara)
        {
            
            if (ModelState.IsValid)
            {
                var user = _httpContextAccessor.HttpContext.User;
                var userFromDatabase = await _userManager.GetUserAsync(user);
                if (userFromDatabase != null 
                    && userFromDatabase.StudentId == prijavaKvara.StudentID)
                    prijavaKvara.createdByUserId = userFromDatabase.Id;

                _context.Add(prijavaKvara);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", prijavaKvara.StudentID);
            return View(prijavaKvara);
        }

        // GET: PrijavaKvara/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prijavaKvara = await _context.PrijavaKvara.FindAsync(id);
            if (prijavaKvara == null)
            {
                return NotFound();
            }
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", prijavaKvara.StudentID);
            return View(prijavaKvara);
        }

        // POST: PrijavaKvara/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrijavaKvaraID,StudentID,TipKvara,OpisKvara,VrijemePrijave,VrijemeRjesenja,HitanKvar,Rijeseno")] PrijavaKvara prijavaKvara)
        {
            if (id != prijavaKvara.PrijavaKvaraID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prijavaKvara);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrijavaKvaraExists(prijavaKvara.PrijavaKvaraID))
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
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", prijavaKvara.StudentID);
            return View(prijavaKvara);
        }

        // GET: PrijavaKvara/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prijavaKvara = await _context.PrijavaKvara
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.PrijavaKvaraID == id);
            if (prijavaKvara == null)
            {
                return NotFound();
            }

            return View(prijavaKvara);
        }

        // POST: PrijavaKvara/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prijavaKvara = await _context.PrijavaKvara.FindAsync(id);
            _context.PrijavaKvara.Remove(prijavaKvara);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrijavaKvaraExists(int id)
        {
            return _context.PrijavaKvara.Any(e => e.PrijavaKvaraID == id);
        }
    }
}
