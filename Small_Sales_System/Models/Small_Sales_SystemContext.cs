using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Small_Sales_System.Models
{
    public partial class Small_Sales_SystemContext : DbContext
    {
        public Small_Sales_SystemContext()
        {
        }

        public Small_Sales_SystemContext(DbContextOptions<Small_Sales_SystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Conceptos> Conceptos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-JBT31LT\\SQLEXPRESS ; database=Small_Sales_System; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("Fecha_Registro")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Conceptos>(entity =>
            {
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdProductos).HasColumnName("idProductos");

                entity.Property(e => e.Precio).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.IdProductosNavigation)
                    .WithMany(p => p.Conceptos)
                    .HasForeignKey(d => d.IdProductos)
                    .HasConstraintName("FK_Conceptos_Productos");

                entity.HasOne(d => d.IdVentasNavigation)
                    .WithMany(p => p.Conceptos)
                    .HasForeignKey(d => d.IdVentas)
                    .HasConstraintName("FK_Conceptos_Ventas");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("Fecha_Registro")
                    .HasColumnType("date");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK_Productos_Tipo_Producto");
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.ToTable("Tipo_Producto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Total).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Ventas_Cliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
