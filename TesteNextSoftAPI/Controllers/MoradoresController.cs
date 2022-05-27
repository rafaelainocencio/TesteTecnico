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
    public class MoradoresController : ControllerBase
    {
        private readonly TesteNextSoftContext _context;

        public MoradoresController(TesteNextSoftContext context)
        {
            _context = context;
        }

        // GET: api/Moradores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Morador>>> GetMorador()
        {
            return await _context.Morador.Include("Familia").ToListAsync();
        }

        // GET: api/Moradores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Morador>> GetMorador(int id)
        {
            var morador = await _context.Morador.FindAsync(id);

            if (morador == null)
            {
                return NotFound();
            }

            return morador;
        }

        // PUT: api/Moradores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMorador(int id, Morador morador)
        {
            if (id != morador.Id)
            {
                return BadRequest();
            }

            _context.Entry(morador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoradorExists(id))
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

        // POST: api/Moradores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Morador>> PostMorador(Morador morador)
        {
            _context.Morador.Add(morador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMorador", new { id = morador.Id }, morador);
        }

        // DELETE: api/Moradores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Morador>> DeleteMorador(int id)
        {
            var morador = await _context.Morador.FindAsync(id);
            if (morador == null)
            {
                return NotFound();
            }

            _context.Morador.Remove(morador);
            await _context.SaveChangesAsync();

            return morador;
        }

        private bool MoradorExists(int id)
        {
            return _context.Morador.Any(e => e.Id == id);
        }
    }
}
