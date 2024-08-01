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
    public class ProcessoSeletivoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProcessoSeletivoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProcessoSeletivo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcessoSeletivo>>> GetProcessoSeletivo()
        {
            return await _context.ProcessoSeletivo.ToListAsync();
        }

        // GET: api/ProcessoSeletivo/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessoSeletivo>> GetProcessoSeletivo(int id)
        {
            var ProcessoSeletivo = await _context.ProcessoSeletivo.FindAsync(id);
            if (ProcessoSeletivo == null)
            {
                return NotFound();
            }
            return ProcessoSeletivo;
        }

        // POST: api/ProcessoSeletivo
        [HttpPost]
        public async Task<ActionResult<ProcessoSeletivo>> PostProcessoSeletivo(ProcessoSeletivo ProcessoSeletivo)
        {
            _context.ProcessoSeletivo.Add(ProcessoSeletivo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProcessoSeletivo), new { id = ProcessoSeletivo.Id }, ProcessoSeletivo);
        }

        // PUT: api/ProcessoSeletivo/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcessoSeletivo(int id, ProcessoSeletivo ProcessoSeletivo)
        {
            if (id != ProcessoSeletivo.Id)
            {
                return BadRequest();
            }

            _context.Entry(ProcessoSeletivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessoSeletivoExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/ProcessoSeletivo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcessoSeletivo(int id)
        {
            var ProcessoSeletivo = await _context.ProcessoSeletivo.FindAsync(id);
            if (ProcessoSeletivo == null)
            {
                return NotFound();
            }

            _context.ProcessoSeletivo.Remove(ProcessoSeletivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProcessoSeletivoExists(int id)
        {
            return _context.ProcessoSeletivo.Any(e => e.Id == id);
        }
    }
}