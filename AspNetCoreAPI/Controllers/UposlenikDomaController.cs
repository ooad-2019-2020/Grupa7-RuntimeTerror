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
    public class UposlenikDomaController : ControllerBase
    {
        private readonly StudentskidomContext _context;

        public UposlenikDomaController(StudentskidomContext context)
        {
            _context = context;
        }

        // GET: api/UposlenikDoma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UposlenikDoma>>> GetUposlenikDoma()
        {
            return await _context.UposlenikDoma.ToListAsync();
        }

        // GET: api/UposlenikDoma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UposlenikDoma>> GetUposlenikDoma(int id)
        {
            var uposlenikDoma = await _context.UposlenikDoma.FindAsync(id);

            if (uposlenikDoma == null)
            {
                return NotFound();
            }

            return uposlenikDoma;
        }

        // PUT: api/UposlenikDoma/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUposlenikDoma(int id, UposlenikDoma uposlenikDoma)
        {
            if (id != uposlenikDoma.UposlenikDomaId)
            {
                return BadRequest();
            }

            _context.Entry(uposlenikDoma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UposlenikDomaExists(id))
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

        // POST: api/UposlenikDoma
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UposlenikDoma>> PostUposlenikDoma(UposlenikDoma uposlenikDoma)
        {
            _context.UposlenikDoma.Add(uposlenikDoma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUposlenikDoma", new { id = uposlenikDoma.UposlenikDomaId }, uposlenikDoma);
        }

        // DELETE: api/UposlenikDoma/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UposlenikDoma>> DeleteUposlenikDoma(int id)
        {
            var uposlenikDoma = await _context.UposlenikDoma.FindAsync(id);
            if (uposlenikDoma == null)
            {
                return NotFound();
            }

            _context.UposlenikDoma.Remove(uposlenikDoma);
            await _context.SaveChangesAsync();

            return uposlenikDoma;
        }

        private bool UposlenikDomaExists(int id)
        {
            return _context.UposlenikDoma.Any(e => e.UposlenikDomaId == id);
        }
    }
}
