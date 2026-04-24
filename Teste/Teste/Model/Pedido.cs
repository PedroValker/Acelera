using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Model
{
    public class ItemPedido
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }

    public class Pedido
    {
        public string NomePedido { get; set; }
        public string Recebedor { get; set; }
        public string Endereco { get; set; }
        public string FormaPagamento { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }

        public List<ItemPedido> Itens { get; set; }
        public string Observacoes { get; set; }
    }
}
