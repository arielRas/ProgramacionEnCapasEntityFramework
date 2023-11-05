using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class ContextDb : DbContext
    {
        public ContextDb()
            : base("name=ContextDb")
        {
        }

        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Producto_Pedido> Producto_Pedido { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                .HasMany(e => e.Producto_Pedido)
                .WithRequired(e => e.Pedido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.PRECIO)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Producto_Pedido)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto_Pedido>()
                .Property(e => e.SUBTOTAL)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.DIRECCION)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.CIUDAD)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Pedido)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.DNI_CLIENTE);
        }
    }
}
