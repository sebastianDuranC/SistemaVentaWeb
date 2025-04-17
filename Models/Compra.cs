using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class Compra
{
    public int Id { get; set; }

    public int ProveedorId { get; set; }

    public int UsuarioId { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Proveedor Proveedor { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
