using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Teste.Model;

namespace Teste.ViewModel
{
    public class AcompanharPedidoViewModel : INotifyPropertyChanged
    {
        public Pedido Pedido { get; set; }

        public ObservableCollection<ItemPedido> Itens =>
            new ObservableCollection<ItemPedido>(Pedido.Itens);

        public ICommand EditarCommand { get; }
        public ICommand CancelarCommand { get; }

        public AcompanharPedidoViewModel()
        {
            Pedido = new Pedido
            {
                NomePedido = "Cesta Premium",
                Recebedor = "Maria José",
                Endereco = "R. Prefeita Adelle de Moraes - Cachoeira Paulista,SP",
                FormaPagamento = "Pix",
                Status = "Pendente",
                Total = 574.50m,
                Observacoes = "Trocar farinha por melancia doce",
                Itens = new List<ItemPedido>
            {
                new ItemPedido { Nome = "Azeite de Oliva Extra", Quantidade = 2 },
                new ItemPedido { Nome = "Arroz Arbóreo", Quantidade = 3 },
                new ItemPedido { Nome = "Café em Grãos", Quantidade = 1 }
            }
            };

            EditarCommand = new RelayCommand(_ => Editar());
            CancelarCommand = new RelayCommand(_ => Cancelar());
        }

        private void Editar()
        {
            // lógica de edição
        }

        private void Cancelar()
        {
            // lógica de cancelamento
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}