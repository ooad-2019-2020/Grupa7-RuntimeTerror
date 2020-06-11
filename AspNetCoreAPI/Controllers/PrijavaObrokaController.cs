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
    public class PrijavaObrokaController : ControllerBase
    {
        private readonly StudentskidomContext _context;

        public PrijavaObrokaController(StudentskidomContext context)
        {
            _context = context;
        }

        // GET: api/PrijavaObroka
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrijavaObroka>>> GetPrijavaObroka()
        {
            return await _context.PrijavaObroka.ToListAsync();
        }

        // GET: api/PrijavaObroka/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrijavaObroka>> GetPrijavaObroka(int id)
        {
            var prijavaObroka = await _context.PrijavaObroka.FindAsync(id);

            if (prijavaObroka == null)
            {
                return NotFound();
            }

            return prijavaObroka;
        }

        // PUT: api/PrijavaObroka/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrijavaObroka(int id, PrijavaObroka prijavaObroka)
        {
            if (id != prijavaObroka.PrijavaObrokaId)
            {
                return BadRequest();
            }

            _context.Entry(prijavaObroka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrijavaObrokaExists(id))
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

        // POST: api/PrijavaObroka
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PrijavaObroka>> PostPrijavaObroka(PrijavaObroka prijavaObroka)
        {
            _context.PrijavaObroka.Add(prijavaObroka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrijavaObroka", new { id = prijavaObroka.PrijavaObrokaId }, prijavaObroka);
        }

        // DELETE: api/PrijavaObroka/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrijavaObroka>> DeletePrijavaObroka(int id)
        {
            var prijavaObroka = await _context.PrijavaObroka.FindAsync(id);
            if (prijavaObroka == null)
            {
                return NotFound();
            }

            _context.PrijavaObroka.Remove(prijavaObroka);
            await _context.SaveChangesAsync();

            return prijavaObroka;
        }

        private bool PrijavaObrokaExists(int id)
        {
            return _context.PrijavaObroka.Any(e => e.PrijavaObrokaId == id);
        }
    }
}
