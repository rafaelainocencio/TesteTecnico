using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteNextSoft.Data;
using TesteNextSoft.Models;

namespace TesteNextSoftAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondominiosController : ControllerBase
    {
        private readonly TesteNextSoftContext _context;

        public CondominiosController(TesteNextSoftContext context)
        {
            _context = context;
        }

        // GET: api/Condominios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Condominio>>> GetCondominio()
        {
            return await _context.Condominio.ToListAsync();
        }

        // GET: api/Condominios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Condominio>> GetCondominio(int id)
        {
            var condominio = await _context.Condominio.FindAsync(id);

            if (condominio == null)
            {
                return NotFound();
            }

            return condominio;
        }

        // PUT: api/Condominios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondominio(int id, Condominio condominio)
        {
            if (id != condominio.Id)
            {
                return BadRequest();
            }

            _context.Entry(condominio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondominioExists(id))
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

        // POST: api/Condominios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Condominio>> PostCondominio(Condominio condominio)
        {
            _context.Condominio.Add(condominio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCondominio", new { id = condominio.Id }, condominio);
        }

        // DELETE: api/Condominios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Condominio>> DeleteCondominio(int id)
        {
            var condominio = await _context.Condominio.FindAsync(id);
            if (condominio == null)
            {
                return NotFound();
            }

            _context.Condominio.Remove(condominio);
            await _context.SaveChangesAsync();

            return condominio;
        }

        private bool CondominioExists(int id)
        {
            return _context.Condominio.Any(e => e.Id == id);
        }
    }
}
