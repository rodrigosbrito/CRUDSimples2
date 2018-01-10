using System;

namespace CRUDSimples2.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Descricao { get; set; }
    }
}