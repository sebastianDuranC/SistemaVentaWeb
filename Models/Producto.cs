using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int CategoriaId { get; set; }

    public decimal PrecioCompra { get; set; }

    public decimal PrecioVenta { get; set; }

    public string? FotoUrl { get; set; }

    public int ProveedorId { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<MovimientoProducto> MovimientoProductos { get; set; } = new List<MovimientoProducto>();

    public virtual ICollection<PlatoProducto> PlatoProductos { get; set; } = new List<PlatoProducto>();

    public virtual Proveedor Proveedor { get; set; } = null!;

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
