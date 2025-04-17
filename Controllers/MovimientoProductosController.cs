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
    public class MovimientoProductosController : Controller
    {
        private readonly ChurrasqueriaElFogonContext _context;

        public MovimientoProductosController(ChurrasqueriaElFogonContext context)
        {
            _context = context;
        }

        // GET: MovimientoProductos
        public async Task<IActionResult> Index()
        {
            var churrasqueriaElFogonContext = _context.MovimientoProductos.Include(m => m.Movimiento).Include(m => m.Producto);
            return View(await churrasqueriaElFogonContext.ToListAsync());
        }

        // GET: MovimientoProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoProducto = await _context.MovimientoProductos
                .Include(m => m.Movimiento)
                .Include(m => m.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimientoProducto == null)
            {
                return NotFound();
            }

            return View(movimientoProducto);
        }

        // GET: MovimientoProductos/Create
        public IActionResult Create()
        {
            ViewData["MovimientoId"] = new SelectList(_context.Movimientos, "Id", "Id");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id");
            return View();
        }

        // POST: MovimientoProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovimientoId,ProductoId,Cantidad")] MovimientoProducto movimientoProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimientoProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovimientoId"] = new SelectList(_context.Movimientos, "Id", "Id", movimientoProducto.MovimientoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id", movimientoProducto.ProductoId);
            return View(movimientoProducto);
        }

        // GET: MovimientoProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoProducto = await _context.MovimientoProductos.FindAsync(id);
            if (movimientoProducto == null)
            {
                return NotFound();
            }
            ViewData["MovimientoId"] = new SelectList(_context.Movimientos, "Id", "Id", movimientoProducto.MovimientoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id", movimientoProducto.ProductoId);
            return View(movimientoProducto);
        }

        // POST: MovimientoProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovimientoId,ProductoId,Cantidad")] MovimientoProducto movimientoProducto)
        {
            if (id != movimientoProducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimientoProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientoProductoExists(movimientoProducto.Id))
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
            ViewData["MovimientoId"] = new SelectList(_context.Movimientos, "Id", "Id", movimientoProducto.MovimientoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id", movimientoProducto.ProductoId);
            return View(movimientoProducto);
        }

        // GET: MovimientoProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoProducto = await _context.MovimientoProductos
                .Include(m => m.Movimiento)
                .Include(m => m.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimientoProducto == null)
            {
                return NotFound();
            }

            return View(movimientoProducto);
        }

        // POST: MovimientoProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimientoProducto = await _context.MovimientoProductos.FindAsync(id);
            if (movimientoProducto != null)
            {
                _context.MovimientoProductos.Remove(movimientoProducto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientoProductoExists(int id)
        {
            return _context.MovimientoProductos.Any(e => e.Id == id);
        }
    }
}
