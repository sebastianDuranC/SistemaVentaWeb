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
    public class TipoVentasController : Controller
    {
        private readonly ChurrasqueriaElFogonContext _context;

        public TipoVentasController(ChurrasqueriaElFogonContext context)
        {
            _context = context;
        }

        // GET: TipoVentas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoVenta.ToListAsync());
        }

        // GET: TipoVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoVenta = await _context.TipoVenta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoVenta == null)
            {
                return NotFound();
            }

            return View(tipoVenta);
        }

        // GET: TipoVentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] TipoVenta tipoVenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoVenta);
        }

        // GET: TipoVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoVenta = await _context.TipoVenta.FindAsync(id);
            if (tipoVenta == null)
            {
                return NotFound();
            }
            return View(tipoVenta);
        }

        // POST: TipoVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] TipoVenta tipoVenta)
        {
            if (id != tipoVenta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoVentaExists(tipoVenta.Id))
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
            return View(tipoVenta);
        }

        // GET: TipoVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoVenta = await _context.TipoVenta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoVenta == null)
            {
                return NotFound();
            }

            return View(tipoVenta);
        }

        // POST: TipoVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoVenta = await _context.TipoVenta.FindAsync(id);
            if (tipoVenta != null)
            {
                _context.TipoVenta.Remove(tipoVenta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoVentaExists(int id)
        {
            return _context.TipoVenta.Any(e => e.Id == id);
        }
    }
}
