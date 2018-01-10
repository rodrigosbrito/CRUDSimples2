using System.Collections.Generic;

namespace CRUDSimples2.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            Pedidos = new List<Pedido>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
