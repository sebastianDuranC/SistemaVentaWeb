using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class Garantia
{
    public int Id { get; set; }

    public int VentaId { get; set; }

    public decimal Monto { get; set; }

    public virtual Venta Venta { get; set; } = null!;
}
