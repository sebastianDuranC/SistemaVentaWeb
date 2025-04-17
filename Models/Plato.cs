using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class Plato
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public string? FotoUrl { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual ICollection<PlatoProducto> PlatoProductos { get; set; } = new List<PlatoProducto>();
}
