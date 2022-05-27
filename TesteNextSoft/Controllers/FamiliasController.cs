using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteNextSoft.Data;
using TesteNextSoft.Models;
using TesteNextSoft.Services;

namespace TesteNextSoft.Controllers
{
    public class FamiliasController : Controller
    {
        private readonly TesteNextSoftContext _context;
        private readonly FamiliaService _familiaService;

        public FamiliasController(TesteNextSoftContext context, FamiliaService familiaService)
        {
            _context = context;
            _familiaService = familiaService;
        }

        // GET: Familias
        public async Task<IActionResult> Index()
        {
            var testeNextSoftContext = _context.Familia.Include(f => f.Condominio);
            return View(await testeNextSoftContext.ToListAsync());
        }

        // GET: Familias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familia
                .Include(f => f.Condominio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familia == null)
            {
                return NotFound();
            }

            return View(familia);
        }

        // GET: Familias/Create
        public IActionResult Create()
        {
            ViewData["CondominioId"] = new SelectList(_context.Condominio, "Id", "Nome");
            return View();
        }

        // POST: Familias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CondominioId,Apto,AreaApto,FracaoIdeal,ValorIptuProporcional")] Familia familia)
        {
            if (ModelState.IsValid)
            {
                await _familiaService.InsertAsync(familia);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CondominioId"] = new SelectList(_context.Condominio, "Id", "Nome", familia.CondominioId);
            return  View(familia);
        }

        // GET: Familias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familia.FindAsync(id);
            if (familia == null)
            {
                return NotFound();
            }
            ViewData["CondominioId"] = new SelectList(_context.Condominio, "Id", "Nome", familia.CondominioId);
            return View(familia);
        }

        // POST: Familias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CondominioId,Apto,AreaApto,FracaoIdeal,ValorIptuProporcional")] Familia familia)
        {
            if (id != familia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _familiaService.UpdateAsync(familia);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliaExists(familia.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CondominioId"] = new SelectList(_context.Condominio, "Id", "Nome", familia.CondominioId);
            return View(familia);
        }

        // GET: Familias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familia
                .Include(f => f.Condominio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familia == null)
            {
                return NotFound();
            }

            return View(familia);
        }

        // POST: Familias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familia = await _context.Familia.FindAsync(id);
            _context.Familia.Remove(familia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliaExists(int id)
        {
            return _context.Familia.Any(e => e.Id == id);
        }
    }
}
