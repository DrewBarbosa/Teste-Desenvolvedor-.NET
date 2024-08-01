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
    public class OfertaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OfertaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/oferta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oferta>>> Getoferta()
        {
            return await _context.Curso.ToListAsync();
        }

        // GET: api/oferta/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Oferta>> Getoferta(int id)
        {
            var oferta = await _context.Curso.FindAsync(id);
            if (oferta == null)
            {
                return NotFound();
            }
            return oferta;
        }

        // POST: api/oferta
        [HttpPost]
        public async Task<ActionResult<Oferta>> Postoferta(Oferta Oferta)
        {
            _context.Curso.Add(Oferta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Getoferta), new { id = Oferta.Id }, Oferta);
        }

        // PUT: api/oferta/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Putoferta(int id, Oferta oferta)
        {
            if (id != oferta.Id)
            {
                return BadRequest();
            }

            _context.Entry(oferta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ofertaExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/oferta/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteoferta(int id)
        {
            var oferta = await _context.Curso.FindAsync(id);
            if (oferta == null)
            {
                return NotFound();
            }

            _context.Curso.Remove(oferta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ofertaExists(int id)
        {
            return _context.Curso.Any(e => e.Id == id);
        }
    }
}