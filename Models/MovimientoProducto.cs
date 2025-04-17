using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class MovimientoProducto
{
    public int Id { get; set; }

    public int MovimientoId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public virtual Movimiento Movimiento { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
