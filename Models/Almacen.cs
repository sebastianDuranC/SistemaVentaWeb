using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class Almacen
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
