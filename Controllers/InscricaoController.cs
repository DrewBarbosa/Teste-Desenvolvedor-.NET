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
    public class InscricaoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InscricaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/inscricao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inscricao>>> GetInscricoes()
        {
            return await _context.Inscricao.ToListAsync();
        }

        // GET: api/inscricao/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Inscricao>> GetInscricao(int id)
        {
            var inscricao = await _context.Inscricao.FindAsync(id);
            if (inscricao == null)
            {
                return NotFound();
            }
            return inscricao;
        }

        // POST: api/inscricao
        [HttpPost]
        public async Task<ActionResult<Inscricao>> PostInscricao(Inscricao inscricao)
        {
            _context.Inscricao.Add(inscricao);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInscricao), new { id = inscricao.Id }, inscricao);
        }

        // PUT: api/inscricao/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscricao(int id, Inscricao inscricao)
        {
            if (id != inscricao.Id)
            {
                return BadRequest();
            }

            _context.Entry(inscricao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscricaoExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/inscricao/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscricao(int id)
        {
            var inscricao = await _context.Inscricao.FindAsync(id);
            if (inscricao == null)
            {
                return NotFound();
            }

            _context.Inscricao.Remove(inscricao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/inscricao/cpf/{cpf}
        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<IEnumerable<Inscricao>>> GetInscricoesPorCPF(string cpf)
        {
             // Verifica se há um candidato com o CPF fornecido
            var candidato = await _context.Candidato.FirstOrDefaultAsync(c => c.CPF == cpf);
    
            // Se o candidato não for encontrado, retorna NotFound
            if (candidato == null)
            {
                return NotFound();
            }

            // Obtém Id do candidato após identificá-lo pelo CPF e fazer uma validação se existe no banco ou não o cadastro
            var candidatoId = candidato.Id;

            // Obtém as inscrições correspondentes ao CPF do candidato encontrado
            var inscricoes = await _context.Inscricao.Where(i => i.LeadID == candidatoId).ToListAsync();

            // Se nenhuma inscrição for encontrada, pode retornar Ok com uma lista vazia ou uma mensagem
            return Ok(inscricoes);
        }

        // GET: api/inscricao/oferta/{ofertaId}
        [HttpGet("oferta/{ofertaId}")]
        public async Task<ActionResult<IEnumerable<Inscricao>>> GetInscricoesPorOferta(int ofertaId)
        {
            var inscricoes = await _context.Inscricao.Where(i => i.OfertaId == ofertaId).ToListAsync();
            return inscricoes;
        }

        private bool InscricaoExists(int id)
        {
            return _context.Inscricao.Any(e => e.Id == id);
        }
    }
}