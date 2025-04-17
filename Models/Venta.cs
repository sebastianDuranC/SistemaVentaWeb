using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class Venta
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Total { get; set; }

    public int MetodoPagoId { get; set; }

    public decimal Cambio { get; set; }

    public int TipoVentaId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual ICollection<Garantia> Garantia { get; set; } = new List<Garantia>();

    public virtual MetodoPago MetodoPago { get; set; } = null!;

    public virtual TipoVenta TipoVenta { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
