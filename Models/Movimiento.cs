using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class Movimiento
{
    public int Id { get; set; }

    public string Motivo { get; set; } = null!;

    public string TipoMovimiento { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public int UsuarioId { get; set; }

    public virtual ICollection<MovimientoProducto> MovimientoProductos { get; set; } = new List<MovimientoProducto>();

    public virtual Usuario Usuario { get; set; } = null!;
}
