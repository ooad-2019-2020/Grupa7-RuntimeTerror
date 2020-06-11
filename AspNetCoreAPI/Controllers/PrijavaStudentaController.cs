using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreAPI;

namespace AspNetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrijavaStudentaController : ControllerBase
    {
        private readonly StudentskidomContext _context;

        public PrijavaStudentaController(StudentskidomContext context)
        {
            _context = context;
        }

        // GET: api/PrijavaStudenta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrijavaStudenta>>> GetPrijavaStudenta()
        {
            return await _context.PrijavaStudenta.ToListAsync();
        }

        // GET: api/PrijavaStudenta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrijavaStudenta>> GetPrijavaStudenta(int id)
        {
            var prijavaStudenta = await _context.PrijavaStudenta.FindAsync(id);

            if (prijavaStudenta == null)
            {
                return NotFound();
            }

            return prijavaStudenta;
        }

        // PUT: api/PrijavaStudenta/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrijavaStudenta(int id, PrijavaStudenta prijavaStudenta)
        {
            if (id != prijavaStudenta.PrijavaStudentaId)
            {
                return BadRequest();
            }

            _context.Entry(prijavaStudenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrijavaStudentaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PrijavaStudenta
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PrijavaStudenta>> PostPrijavaStudenta(PrijavaStudenta prijavaStudenta)
        {
            _context.PrijavaStudenta.Add(prijavaStudenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrijavaStudenta", new { id = prijavaStudenta.PrijavaStudentaId }, prijavaStudenta);
        }

        // DELETE: api/PrijavaStudenta/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrijavaStudenta>> DeletePrijavaStudenta(int id)
        {
            var prijavaStudenta = await _context.PrijavaStudenta.FindAsync(id);
            if (prijavaStudenta == null)
            {
                return NotFound();
            }

            _context.PrijavaStudenta.Remove(prijavaStudenta);
            await _context.SaveChangesAsync();

            return prijavaStudenta;
        }

        private bool PrijavaStudentaExists(int id)
        {
            return _context.PrijavaStudenta.Any(e => e.PrijavaStudentaId == id);
        }
    }
}
