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
    public class PrijavaKvaraController : ControllerBase
    {
        private readonly StudentskidomContext _context;

        public PrijavaKvaraController(StudentskidomContext context)
        {
            _context = context;
        }

        // GET: api/PrijavaKvara
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrijavaKvara>>> GetPrijavaKvara()
        {
            return await _context.PrijavaKvara.ToListAsync();
        }

        // GET: api/PrijavaKvara/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrijavaKvara>> GetPrijavaKvara(int id)
        {
            var prijavaKvara = await _context.PrijavaKvara.FindAsync(id);

            if (prijavaKvara == null)
            {
                return NotFound();
            }

            return prijavaKvara;
        }

        // PUT: api/PrijavaKvara/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrijavaKvara(int id, PrijavaKvara prijavaKvara)
        {
            if (id != prijavaKvara.PrijavaKvaraId)
            {
                return BadRequest();
            }

            _context.Entry(prijavaKvara).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrijavaKvaraExists(id))
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

        // POST: api/PrijavaKvara
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PrijavaKvara>> PostPrijavaKvara(PrijavaKvara prijavaKvara)
        {
            _context.PrijavaKvara.Add(prijavaKvara);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrijavaKvara", new { id = prijavaKvara.PrijavaKvaraId }, prijavaKvara);
        }

        // DELETE: api/PrijavaKvara/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrijavaKvara>> DeletePrijavaKvara(int id)
        {
            var prijavaKvara = await _context.PrijavaKvara.FindAsync(id);
            if (prijavaKvara == null)
            {
                return NotFound();
            }

            _context.PrijavaKvara.Remove(prijavaKvara);
            await _context.SaveChangesAsync();

            return prijavaKvara;
        }

        private bool PrijavaKvaraExists(int id)
        {
            return _context.PrijavaKvara.Any(e => e.PrijavaKvaraId == id);
        }
    }
}
