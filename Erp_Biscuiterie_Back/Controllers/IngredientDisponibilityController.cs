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
    public class IngredientDisponibilityController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public IngredientDisponibilityController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/IngredientDisponibility
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientDisponibily>>> GetIngredientDisponibily()
        {
            return await _context.IngredientDisponibily.ToListAsync();
        }

        // GET: api/IngredientDisponibility/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientDisponibily>> GetIngredientDisponibily(int id)
        {
            var ingredientDisponibily = await _context.IngredientDisponibily.FindAsync(id);

            if (ingredientDisponibily == null)
            {
                return NotFound();
            }

            return ingredientDisponibily;
        }

        // PUT: api/IngredientDisponibility/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredientDisponibily(int id, IngredientDisponibily ingredientDisponibily)
        {
            if (id != ingredientDisponibily.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingredientDisponibily).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientDisponibilyExists(id))
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

        // POST: api/IngredientDisponibility
        [HttpPost]
        public async Task<ActionResult<IngredientDisponibily>> PostIngredientDisponibily(IngredientDisponibily ingredientDisponibily)
        {
            _context.IngredientDisponibily.Add(ingredientDisponibily);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredientDisponibily", new { id = ingredientDisponibily.Id }, ingredientDisponibily);
        }

        // DELETE: api/IngredientDisponibility/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IngredientDisponibily>> DeleteIngredientDisponibily(int id)
        {
            var ingredientDisponibily = await _context.IngredientDisponibily.FindAsync(id);
            if (ingredientDisponibily == null)
            {
                return NotFound();
            }

            _context.IngredientDisponibily.Remove(ingredientDisponibily);
            await _context.SaveChangesAsync();

            return ingredientDisponibily;
        }

        private bool IngredientDisponibilyExists(int id)
        {
            return _context.IngredientDisponibily.Any(e => e.Id == id);
        }
    }
}
