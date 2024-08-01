using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_Desenvolvedor_.NET.Data;
using Teste_Desenvolvedor_.NET.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Desenvolvedor_.NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeadController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LeadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Lead
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> GetLead()
        {
            return await _context.Candidato.ToListAsync();
        }

        // GET: api/Lead/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Lead>> GetLead(int id)
        {
            var Lead = await _context.Candidato.FindAsync(id);
            if (Lead == null)
            {
                return NotFound();
            }
            return Lead;
        }

        // POST: api/Lead
        [HttpPost]
        public async Task<ActionResult<Lead>> PostLead(Lead Lead)
        {
            _context.Candidato.Add(Lead);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLead), new { id = Lead.Id }, Lead);
        }

        // PUT: api/Lead/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLead(int id, Lead Lead)
        {
            if (id != Lead.Id)
            {
                return BadRequest();
            }

            _context.Entry(Lead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Lead/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLead(int id)
        {
            var Lead = await _context.Candidato.FindAsync(id);
            if (Lead == null)
            {
                return NotFound();
            }

            _context.Candidato.Remove(Lead);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeadExists(int id)
        {
            return _context.Candidato.Any(e => e.Id == id);
        }
    }
}