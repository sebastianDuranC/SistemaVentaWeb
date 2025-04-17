using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class Stock
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public int AlmacenId { get; set; }

    public int Cantidad { get; set; }

    public virtual Almacen Almacen { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
