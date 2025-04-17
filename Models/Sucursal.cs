using System;
using System.Collections.Generic;

namespace SistemaVentaWeb.Models;

public partial class Sucursal
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Logo { get; set; }

    public string Direccion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
