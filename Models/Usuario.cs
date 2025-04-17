using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Contra { get; set; } = null!;

    public int RolId { get; set; }

    public int SucursalId { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

    public virtual Rol Rol { get; set; } = null!;

    public virtual Sucursal Sucursal { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
