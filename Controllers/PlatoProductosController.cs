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
    public class PlatoProductosController : Controller
    {
        private readonly ChurrasqueriaElFogonContext _context;

        public PlatoProductosController(ChurrasqueriaElFogonContext context)
        {
            _context = context;
        }

        // GET: PlatoProductos
        public async Task<IActionResult> Index()
        {
            var churrasqueriaElFogonContext = _context.PlatoProductos.Include(p => p.Plato).Include(p => p.Producto);
            return View(await churrasqueriaElFogonContext.ToListAsync());
        }

        // GET: PlatoProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platoProducto = await _context.PlatoProductos
                .Include(p => p.Plato)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (platoProducto == null)
            {
                return NotFound();
            }

            return View(platoProducto);
        }

        // GET: PlatoProductos/Create
        public IActionResult Create()
        {
            ViewData["PlatoId"] = new SelectList(_context.Platos, "Id", "Id");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id");
            return View();
        }

        // POST: PlatoProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlatoId,ProductoId,Cantidad,Unidad")] PlatoProducto platoProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(platoProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlatoId"] = new SelectList(_context.Platos, "Id", "Id", platoProducto.PlatoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id", platoProducto.ProductoId);
            return View(platoProducto);
        }

        // GET: PlatoProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platoProducto = await _context.PlatoProductos.FindAsync(id);
            if (platoProducto == null)
            {
                return NotFound();
            }
            ViewData["PlatoId"] = new SelectList(_context.Platos, "Id", "Id", platoProducto.PlatoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id", platoProducto.ProductoId);
            return View(platoProducto);
        }

        // POST: PlatoProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlatoId,ProductoId,Cantidad,Unidad")] PlatoProducto platoProducto)
        {
            if (id != platoProducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(platoProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatoProductoExists(platoProducto.Id))
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
            ViewData["PlatoId"] = new SelectList(_context.Platos, "Id", "Id", platoProducto.PlatoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id", platoProducto.ProductoId);
            return View(platoProducto);
        }

        // GET: PlatoProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platoProducto = await _context.PlatoProductos
                .Include(p => p.Plato)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (platoProducto == null)
            {
                return NotFound();
            }

            return View(platoProducto);
        }

        // POST: PlatoProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var platoProducto = await _context.PlatoProductos.FindAsync(id);
            if (platoProducto != null)
            {
                _context.PlatoProductos.Remove(platoProducto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatoProductoExists(int id)
        {
            return _context.PlatoProductos.Any(e => e.Id == id);
        }
    }
}
