using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteNextSoft.Data;
using TesteNextSoft.Models;

namespace TesteNextSoft.Controllers
{
    public class MoradoresController : Controller
    {
        private readonly TesteNextSoftContext _context;

        public MoradoresController(TesteNextSoftContext context)
        {
            _context = context;
        }

        // GET: Moradores
        public async Task<IActionResult> Index()
        {
            var testeNextSoftContext = _context.Morador.Include(m => m.Familia);
            return View(await testeNextSoftContext.ToListAsync());
        }

        // GET: Moradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morador = await _context.Morador
                .Include(m => m.Familia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (morador == null)
            {
                return NotFound();
            }

            return View(morador);
        }

        // GET: Moradores/Create
        public IActionResult Create()
        {
            ViewData["FamiliaId"] = new SelectList(_context.Familia, "Id", "Id");
            return View();
        }

        // POST: Moradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FamiliaId,Nome,Idade")] Morador morador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(morador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FamiliaId"] = new SelectList(_context.Familia, "Id", "Id", morador.FamiliaId);
            return View(morador);
        }

        // GET: Moradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morador = await _context.Morador.FindAsync(id);
            if (morador == null)
            {
                return NotFound();
            }
            ViewData["FamiliaId"] = new SelectList(_context.Familia, "Id", "Id", morador.FamiliaId);
            return View(morador);
        }

        // POST: Moradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FamiliaId,Nome,Idade")] Morador morador)
        {
            if (id != morador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(morador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoradorExists(morador.Id))
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
            ViewData["FamiliaId"] = new SelectList(_context.Familia, "Id", "Id", morador.FamiliaId);
            return View(morador);
        }

        // GET: Moradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morador = await _context.Morador
                .Include(m => m.Familia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (morador == null)
            {
                return NotFound();
            }

            return View(morador);
        }

        // POST: Moradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var morador = await _context.Morador.FindAsync(id);
            _context.Morador.Remove(morador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoradorExists(int id)
        {
            return _context.Morador.Any(e => e.Id == id);
        }
    }
}
