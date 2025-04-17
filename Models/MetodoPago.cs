using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class MetodoPago
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
