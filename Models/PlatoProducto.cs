using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class PlatoProducto
{
    public int Id { get; set; }

    public int PlatoId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public string Unidad { get; set; } = null!;

    public virtual Plato Plato { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
