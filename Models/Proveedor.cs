using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class Proveedor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Contacto { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
