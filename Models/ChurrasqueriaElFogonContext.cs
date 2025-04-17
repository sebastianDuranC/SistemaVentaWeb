using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaVentaWeb.Models;

public partial class ChurrasqueriaElFogonContext : DbContext
{
    public ChurrasqueriaElFogonContext()
    {
    }

    public ChurrasqueriaElFogonContext(DbContextOptions<ChurrasqueriaElFogonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Almacen> Almacens { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<Garantia> Garantia { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<MovimientoProducto> MovimientoProductos { get; set; }

    public virtual DbSet<Plato> Platos { get; set; }

    public virtual DbSet<PlatoProducto> PlatoProductos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<TipoVenta> TipoVenta { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ChurrasqueriaElFogon;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Almacen__3214EC270D35C0EC");

            entity.ToTable("Almacen");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC27B33C8D08");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC279B0F9895");

            entity.ToTable("Cliente");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.NumeroLocal).HasMaxLength(50);
            entity.Property(e => e.NumeroPasillo).HasMaxLength(50);
            entity.Property(e => e.TipoCliente).HasMaxLength(50);
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Compra__3214EC2717A3E481");

            entity.ToTable("Compra");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Compras)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Compra__Proveedo__4E88ABD4");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Compras)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Compra__UsuarioI__4F7CD00D");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleC__3214EC27D60EEFCA");

            entity.ToTable("DetalleCompra");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompraId).HasColumnName("CompraID");
            entity.Property(e => e.CostoUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Compra).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.CompraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCo__Compr__52593CB8");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCo__Produ__534D60F1");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleV__3214EC27DB602169");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PlatoId).HasColumnName("PlatoID");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.VentaId).HasColumnName("VentaID");

            entity.HasOne(d => d.Plato).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.PlatoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleVe__Plato__70DDC3D8");

            entity.HasOne(d => d.Venta).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleVe__Venta__6FE99F9F");
        });

        modelBuilder.Entity<Garantia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Garantia__3214EC27F561F728");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.VentaId).HasColumnName("VentaID");

            entity.HasOne(d => d.Venta).WithMany(p => p.Garantia)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Garantia__VentaI__6D0D32F4");
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MetodoPa__3214EC27A27CF265");

            entity.ToTable("MetodoPago");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movimien__3214EC2707A7D8FC");

            entity.ToTable("Movimiento");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Motivo).HasMaxLength(255);
            entity.Property(e => e.TipoMovimiento).HasMaxLength(50);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movimient__Usuar__59063A47");
        });

        modelBuilder.Entity<MovimientoProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movimien__3214EC27DBBFCC7D");

            entity.ToTable("MovimientoProducto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MovimientoId).HasColumnName("MovimientoID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Movimiento).WithMany(p => p.MovimientoProductos)
                .HasForeignKey(d => d.MovimientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movimient__Movim__5BE2A6F2");

            entity.HasOne(d => d.Producto).WithMany(p => p.MovimientoProductos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movimient__Produ__5CD6CB2B");
        });

        modelBuilder.Entity<Plato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Plato__3214EC278B3C9F6A");

            entity.ToTable("Plato");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FotoUrl)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<PlatoProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlatoPro__3214EC27C253FF9D");

            entity.ToTable("PlatoProducto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PlatoId).HasColumnName("PlatoID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Unidad).HasMaxLength(50);

            entity.HasOne(d => d.Plato).WithMany(p => p.PlatoProductos)
                .HasForeignKey(d => d.PlatoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlatoProd__Plato__619B8048");

            entity.HasOne(d => d.Producto).WithMany(p => p.PlatoProductos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlatoProd__Produ__628FA481");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC271AB15DD7");

            entity.ToTable("Producto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.FotoUrl).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PrecioCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__Catego__44FF419A");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__Provee__45F365D3");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proveedo__3214EC27C64D0887");

            entity.ToTable("Proveedor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Contacto).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rol__3214EC273CB62C66");

            entity.ToTable("Rol");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stock__3214EC274F9D9DB3");

            entity.ToTable("Stock");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AlmacenId).HasColumnName("AlmacenID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Almacen).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.AlmacenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stock__AlmacenID__4BAC3F29");

            entity.HasOne(d => d.Producto).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stock__ProductoI__4AB81AF0");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sucursal__3214EC27ACFC6E45");

            entity.ToTable("Sucursal");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Logo).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<TipoVenta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoVent__3214EC275605304D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC27A51C83A1");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Contra).HasMaxLength(15);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__RolID__3B75D760");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__Sucursa__3C69FB99");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Venta__3214EC274F1437BE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cambio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.MetodoPagoId).HasColumnName("MetodoPagoID");
            entity.Property(e => e.TipoVentaId).HasColumnName("TipoVentaID");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__ClienteID__6754599E");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.Venta)
                .HasForeignKey(d => d.MetodoPagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__MetodoPag__693CA210");

            entity.HasOne(d => d.TipoVenta).WithMany(p => p.Venta)
                .HasForeignKey(d => d.TipoVentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__TipoVenta__6A30C649");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Venta)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__UsuarioID__68487DD7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
