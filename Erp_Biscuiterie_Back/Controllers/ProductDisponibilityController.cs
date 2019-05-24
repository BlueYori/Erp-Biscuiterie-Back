using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Erp_Biscuiterie_Back.Business.Context;
using Erp_Biscuiterie_Back.Business.Models;
using System.Net;

namespace Erp_Biscuiterie_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDisponibilityController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ProductDisponibilityController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ProductDisponibility
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDisponibility>>> GetProductDisponibility()
        {
            return await _context.ProductDisponibility.Include(productDisponibility => productDisponibility.Product).ToListAsync();
        }

        // GET: api/ProductDisponibility/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDisponibility>> GetProductDisponibility(int id)
        {
            var productDisponibility = await _context.ProductDisponibility.Include(pd => pd.Product).FirstOrDefaultAsync(p => p.Id == id);

            if (productDisponibility == null)
            {
                return NotFound();
            }

            return productDisponibility;
        }

        // PUT: api/ProductDisponibility/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDisponibility(int id, ProductDisponibility productDisponibility)
        {
            if (id != productDisponibility.Id)
            {
                return BadRequest();
            }

            _context.Entry(productDisponibility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDisponibilityExists(id))
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

        // POST: api/ProductDisponibility
        [HttpPost]
        public async Task<ActionResult<ProductDisponibility>> PostProductDisponibility(ProductDisponibility productDisponibility)
        {
            if (ProductExists(productDisponibility.ProductId))
            {
                return Conflict(new { message = $"Le produit numéro '{productDisponibility.ProductId}' existe déjà." });

            }
            _context.ProductDisponibility.Add(productDisponibility);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDisponibility", new { id = productDisponibility.Id }, productDisponibility);
        }

        // DELETE: api/ProductDisponibility/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDisponibility>> DeleteProductDisponibility(int id)
        {
            var productDisponibility = await _context.ProductDisponibility.FindAsync(id);
            if (productDisponibility == null)
            {
                return NotFound();
            }

            _context.ProductDisponibility.Remove(productDisponibility);
            await _context.SaveChangesAsync();

            return productDisponibility;
        }

        private bool ProductDisponibilityExists(int id)
        {
            return _context.ProductDisponibility.Any(e => e.Id == id);
        }

        private bool ProductExists(int id)
        {
            var product = _context.ProductDisponibility.Find(id);

            if(product == null)
            {
                return false;
            }

            return true;
        }
    }
}
