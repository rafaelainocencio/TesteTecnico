using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteNextSoft.Data;
using TesteNextSoft.Models;
using TesteNextSoft.Services;

namespace TesteNextSoftAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliasController : ControllerBase
    {
        private readonly TesteNextSoftContext _context;
        private readonly TesteNextSoft.Services.FamiliaService _familiaService;

        public FamiliasController(TesteNextSoftContext context, FamiliaService familiaService)
        {
            _context = context;
            _familiaService = familiaService;
        }

        // GET: api/Familias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Familia>>> GetFamilia()
        {

            return await _context.Familia.Include("Condominio").ToListAsync();
        }

        // GET: api/Familias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Familia>> GetFamilia(int id)
        {
            var familia = await _context.Familia.Include("Condominio").FirstOrDefaultAsync(x => x.Id == id);

            if (familia == null)
            {
                return NotFound();
            }

            return familia;
        }

        // PUT: api/Familias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamilia(int id, Familia familia)
        {
            if (id != familia.Id)
            {
                return BadRequest();
            }

            _context.Entry(familia).State = EntityState.Modified;

            try
            {
                await _familiaService.UpdateAsync(familia);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamiliaExists(id))
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

        // POST: api/Familias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Familia>> PostFamilia(Familia familia)
        {
            _familiaService.InsertAsync(familia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFamilia", new { id = familia.Id }, familia);
        }

        // DELETE: api/Familias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Familia>> DeleteFamilia(int id)
        {
            var familia = await _context.Familia.FindAsync(id);
            if (familia == null)
            {
                return NotFound();
            }

            _context.Familia.Remove(familia);
            await _context.SaveChangesAsync();

            return familia;
        }

        private bool FamiliaExists(int id)
        {
            return _context.Familia.Any(e => e.Id == id);
        }
    }
}
