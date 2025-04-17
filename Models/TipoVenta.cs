using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class TipoVenta
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
