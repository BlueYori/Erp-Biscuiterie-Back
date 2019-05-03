using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Erp_Biscuiterie_Back.Business.Context;
using Erp_Biscuiterie_Back.Business.Models;

namespace Erp_Biscuiterie_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReductionController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ReductionController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Reduction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reduction>>> GetReduction()
        {
            return await _context.Reduction.ToListAsync();
        }

        // GET: api/Reduction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reduction>> GetReduction(int id)
        {
            var reduction = await _context.Reduction.FindAsync(id);

            if (reduction == null)
            {
                return NotFound();
            }

            return reduction;
        }

        // PUT: api/Reduction/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReduction(int id, Reduction reduction)
        {
            if (id != reduction.Id)
            {
                return BadRequest();
            }

            _context.Entry(reduction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReductionExists(id))
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

        // POST: api/Reduction
        [HttpPost]
        public async Task<ActionResult<Reduction>> PostReduction(Reduction reduction)
        {
            _context.Reduction.Add(reduction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReduction", new { id = reduction.Id }, reduction);
        }

        // DELETE: api/Reduction/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reduction>> DeleteReduction(int id)
        {
            var reduction = await _context.Reduction.FindAsync(id);
            if (reduction == null)
            {
                return NotFound();
            }

            _context.Reduction.Remove(reduction);
            await _context.SaveChangesAsync();

            return reduction;
        }

        private bool ReductionExists(int id)
        {
            return _context.Reduction.Any(e => e.Id == id);
        }
    }
}
