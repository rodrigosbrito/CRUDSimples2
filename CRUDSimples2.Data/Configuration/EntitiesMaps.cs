using CRUDSimples2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSimples2.Data.Configuration
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            this.HasKey(p => p.Id);
            this.ToTable("Clientes", "dbo");
            this.HasMany(p => p.Pedidos);
        }
    }

    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            this.HasKey(p => p.Id);
            this.ToTable("Pedidos", "dbo");
        }
    }
}
