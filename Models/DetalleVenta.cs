using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class DetalleVenta
{
    public int Id { get; set; }

    public int VentaId { get; set; }

    public int PlatoId { get; set; }

    public int Cantidad { get; set; }

    public decimal Subtotal { get; set; }

    public virtual Plato Plato { get; set; } = null!;

    public virtual Venta Venta { get; set; } = null!;
}
