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
    public class TypeIngredientController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TypeIngredientController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/TypeIngredient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeIngredient>>> GetTypeIngredient()
        {
            return await _context.TypeIngredient.ToListAsync();
        }

        // GET: api/TypeIngredient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeIngredient>> GetTypeIngredient(int id)
        {
            var typeIngredient = await _context.TypeIngredient.FindAsync(id);

            if (typeIngredient == null)
            {
                return NotFound();
            }

            return typeIngredient;
        }

        // PUT: api/TypeIngredient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeIngredient(int id, TypeIngredient typeIngredient)
        {
            if (id != typeIngredient.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeIngredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeIngredientExists(id))
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

        // POST: api/TypeIngredient
        [HttpPost]
        public async Task<ActionResult<TypeIngredient>> PostTypeIngredient(TypeIngredient typeIngredient)
        {
            _context.TypeIngredient.Add(typeIngredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeIngredient", new { id = typeIngredient.Id }, typeIngredient);
        }

        // DELETE: api/TypeIngredient/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeIngredient>> DeleteTypeIngredient(int id)
        {
            var typeIngredient = await _context.TypeIngredient.FindAsync(id);
            if (typeIngredient == null)
            {
                return NotFound();
            }

            _context.TypeIngredient.Remove(typeIngredient);
            await _context.SaveChangesAsync();

            return typeIngredient;
        }

        private bool TypeIngredientExists(int id)
        {
            return _context.TypeIngredient.Any(e => e.Id == id);
        }
    }
}
