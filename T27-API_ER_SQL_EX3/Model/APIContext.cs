using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_EX3.Model
{
    public class APIContext : DbContext
    {
        // IMPORTAMOS LAS OPCIONES DE DbContext
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        // ATRIBUTOS, GETTERS Y SETTERS
        public virtual DbSet<Cajero> Cajero { get; set; }
        public virtual DbSet<Maquina_Registradora> Maquina_Registradora { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        //DEFINIMOS LOS MODELOS DE LA BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cajero>(cajero =>
            {
                // NOMBRE TABLA
                cajero.ToTable("Cajeros");

                // PROPIEDADES DE COLUMNAS
                cajero.Property(e => e.Codigo)
                    .HasColumnName("Codigo");
                cajero.HasKey(k => k.Codigo);

                cajero.Property(e => e.NomApels)
                    .HasColumnName("NomApels")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Maquina_Registradora>(mR =>
            {
                // NOMBRE DE TABLA
                mR.ToTable("Maquinas_Registradoras");

                // PROPIEDADES DE COLUMNAS
                mR.Property(e => e.Codigo)
                    .HasColumnName("Codigo");
                mR.HasKey(k => k.Codigo);

                mR.Property(e => e.Piso)
                    .HasColumnName("Piso");
            });

            modelBuilder.Entity<Producto>(producto =>
            {
                // NOMBRE DE TABLA
                producto.ToTable("Productos");

                // PROPIEDADES DE COLUMNAS
                producto.Property(e => e.Codigo)
                    .HasColumnName("Codigo");
                producto.HasKey(k => k.Codigo);

                producto.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                producto.Property(e => e.Precio)
                    .HasColumnName("Precio");
            });

            modelBuilder.Entity<Venta>(venta =>
            {
                // NOMBRE DE TABLA
                venta.ToTable("Venta");

                // PROPIEDADES DE COLUMNAS
                venta.Property(e => e.Cajero)
                    .HasColumnName("Cajero");

                venta.Property(e => e.Maquina)
                    .HasColumnName("Maquina");

                venta.Property(e => e.Producto)
                    .HasColumnName("Producto");

                venta.HasKey(k => new { k.Cajero, k.Maquina, k.Producto });

                // RELACIONES
                venta.HasOne(r => r.Cajeros)
                    .WithMany(m => m.Ventas)
                    .HasForeignKey(k => k.Cajero)
                    .HasConstraintName("Cajero_fk");
                venta.HasOne(r => r.Maquinas_Registradoras)
                    .WithMany(m => m.Ventas)
                    .HasForeignKey(k => k.Maquina)
                    .HasConstraintName("Maquinas_Registradoras_fk");
                venta.HasOne(r => r.Productos)
                    .WithMany(m => m.Ventas)
                    .HasForeignKey(k => k.Producto)
                    .HasConstraintName("Producto_fk");
            });
        }
    }
}
