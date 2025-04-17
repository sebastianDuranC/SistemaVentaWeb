using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaVentaWeb.Models;

namespace SistemaVentaWeb.Controllers
{
    public class GarantiasController : Controller
    {
        private readonly ChurrasqueriaElFogonContext _context;

        public GarantiasController(ChurrasqueriaElFogonContext context)
        {
            _context = context;
        }

        // GET: Garantias
        public async Task<IActionResult> Index()
        {
            var churrasqueriaElFogonContext = _context.Garantia.Include(g => g.Venta);
            return View(await churrasqueriaElFogonContext.ToListAsync());
        }

        // GET: Garantias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garantia = await _context.Garantia
                .Include(g => g.Venta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garantia == null)
            {
                return NotFound();
            }

            return View(garantia);
        }

        // GET: Garantias/Create
        public IActionResult Create()
        {
            ViewData["VentaId"] = new SelectList(_context.Venta, "Id", "Id");
            return View();
        }

        // POST: Garantias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VentaId,Monto")] Garantia garantia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garantia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VentaId"] = new SelectList(_context.Venta, "Id", "Id", garantia.VentaId);
            return View(garantia);
        }

        // GET: Garantias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garantia = await _context.Garantia.FindAsync(id);
            if (garantia == null)
            {
                return NotFound();
            }
            ViewData["VentaId"] = new SelectList(_context.Venta, "Id", "Id", garantia.VentaId);
            return View(garantia);
        }

        // POST: Garantias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VentaId,Monto")] Garantia garantia)
        {
            if (id != garantia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garantia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarantiaExists(garantia.Id))
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
            ViewData["VentaId"] = new SelectList(_context.Venta, "Id", "Id", garantia.VentaId);
            return View(garantia);
        }

        // GET: Garantias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garantia = await _context.Garantia
                .Include(g => g.Venta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garantia == null)
            {
                return NotFound();
            }

            return View(garantia);
        }

        // POST: Garantias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var garantia = await _context.Garantia.FindAsync(id);
            if (garantia != null)
            {
                _context.Garantia.Remove(garantia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarantiaExists(int id)
        {
            return _context.Garantia.Any(e => e.Id == id);
        }
    }
}
