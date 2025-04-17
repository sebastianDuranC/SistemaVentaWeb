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
    public class VentasController : Controller
    {
        private readonly ChurrasqueriaElFogonContext _context;

        public VentasController(ChurrasqueriaElFogonContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var churrasqueriaElFogonContext = _context.Venta.Include(v => v.Cliente).Include(v => v.MetodoPago).Include(v => v.TipoVenta).Include(v => v.Usuario);
            return View(await churrasqueriaElFogonContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta
                .Include(v => v.Cliente)
                .Include(v => v.MetodoPago)
                .Include(v => v.TipoVenta)
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id");
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPagos, "Id", "Id");
            ViewData["TipoVentaId"] = new SelectList(_context.TipoVenta, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,UsuarioId,Fecha,Total,MetodoPagoId,Cambio,TipoVentaId")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", venta.ClienteId);
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPagos, "Id", "Id", venta.MetodoPagoId);
            ViewData["TipoVentaId"] = new SelectList(_context.TipoVenta, "Id", "Id", venta.TipoVentaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", venta.UsuarioId);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", venta.ClienteId);
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPagos, "Id", "Id", venta.MetodoPagoId);
            ViewData["TipoVentaId"] = new SelectList(_context.TipoVenta, "Id", "Id", venta.TipoVentaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", venta.UsuarioId);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,UsuarioId,Fecha,Total,MetodoPagoId,Cambio,TipoVentaId")] Venta venta)
        {
            if (id != venta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", venta.ClienteId);
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPagos, "Id", "Id", venta.MetodoPagoId);
            ViewData["TipoVentaId"] = new SelectList(_context.TipoVenta, "Id", "Id", venta.TipoVentaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", venta.UsuarioId);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta
                .Include(v => v.Cliente)
                .Include(v => v.MetodoPago)
                .Include(v => v.TipoVenta)
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Venta.FindAsync(id);
            if (venta != null)
            {
                _context.Venta.Remove(venta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
            return _context.Venta.Any(e => e.Id == id);
        }
    }
}
