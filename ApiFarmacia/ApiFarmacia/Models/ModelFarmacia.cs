using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ApiFarmacia.Models
{
    public partial class ModelFarmacia : DbContext
    {
        public ModelFarmacia()
            : base("name=ModelFarmacia")
        {
        }

        public virtual DbSet<Concentracion> Concentracion { get; set; }
        public virtual DbSet<Domiciliario> Domiciliario { get; set; }
        public virtual DbSet<Domicilio> Domicilio { get; set; }
        public virtual DbSet<Estante> Estante { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Presentacion> Presentacion { get; set; }
        public virtual DbSet<Recurso> Recurso { get; set; }
        public virtual DbSet<SQF> SQF { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concentracion>()
                .Property(e => e.Concentracion1)
                .IsUnicode(false);

            modelBuilder.Entity<Domiciliario>()
                .Property(e => e.Domiciliario1)
                .IsUnicode(false);

            modelBuilder.Entity<Domicilio>()
                .Property(e => e.NombreProducto)
                .IsUnicode(false);

            modelBuilder.Entity<Domicilio>()
                .Property(e => e.Concentracion)
                .IsUnicode(false);

            modelBuilder.Entity<Domicilio>()
                .Property(e => e.Presentacion)
                .IsUnicode(false);

            modelBuilder.Entity<Domicilio>()
                .Property(e => e.CodigoProducto)
                .IsUnicode(false);

            modelBuilder.Entity<Domicilio>()
                .Property(e => e.Cantidad)
                .IsUnicode(false);

            modelBuilder.Entity<Domicilio>()
                .Property(e => e.NombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Domicilio>()
                .Property(e => e.ApellidosUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Domicilio>()
                .Property(e => e.IdUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Domicilio>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Domicilio>()
                .Property(e => e.Barrio)
                .IsUnicode(false);

            modelBuilder.Entity<Domicilio>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Domicilio>()
                .Property(e => e.Domiciliario)
                .IsUnicode(false);

            modelBuilder.Entity<Estante>()
                .Property(e => e.NoEstante)
                .IsUnicode(false);

            modelBuilder.Entity<Inventario>()
                .Property(e => e.CodigoProducto)
                .IsUnicode(false);

            modelBuilder.Entity<Inventario>()
                .Property(e => e.NombreProducto)
                .IsUnicode(false);

            modelBuilder.Entity<Inventario>()
                .Property(e => e.Concentracion)
                .IsUnicode(false);

            modelBuilder.Entity<Inventario>()
                .Property(e => e.Presentacion)
                .IsUnicode(false);

            modelBuilder.Entity<Inventario>()
                .Property(e => e.FechaInventario)
                .IsUnicode(false);

            modelBuilder.Entity<Inventario>()
                .Property(e => e.NoEstante)
                .IsUnicode(false);

            modelBuilder.Entity<Inventario>()
                .Property(e => e.FechaVencimiento)
                .IsUnicode(false);

            modelBuilder.Entity<Inventario>()
                .Property(e => e.Cantidad)
                .IsUnicode(false);

            modelBuilder.Entity<Presentacion>()
                .Property(e => e.Presentacion1)
                .IsUnicode(false);

            modelBuilder.Entity<Recurso>()
                .Property(e => e.Recurso1)
                .IsUnicode(false);

            modelBuilder.Entity<SQF>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<SQF>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<SQF>()
                .Property(e => e.Identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<SQF>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<SQF>()
                .Property(e => e.Barrio)
                .IsUnicode(false);

            modelBuilder.Entity<SQF>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SQF>()
                .Property(e => e.Recurso)
                .IsUnicode(false);

            modelBuilder.Entity<SQF>()
                .Property(e => e.Fecha)
                .IsUnicode(false);

            modelBuilder.Entity<SQF>()
                .Property(e => e.Situacion)
                .IsUnicode(false);
        }
    }
}
