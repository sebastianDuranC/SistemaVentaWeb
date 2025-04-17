using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string TipoCliente { get; set; } = null!;

    public string? NumeroPasillo { get; set; }

    public string? NumeroLocal { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
