using CRUDSimples2.Data.Configuration;
using CRUDSimples2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSimples2.Data.Context
{
    public class Context : DbContext
    {
        public Context() : base("ConnectionDB")
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(50));
            modelBuilder.Properties<string>().Where(p => p.Name.Contains("Descricao")).Configure(p => p.HasMaxLength(200));

            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new PedidoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
