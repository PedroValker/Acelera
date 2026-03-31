using System.Collections.ObjectModel;
using TelaClientes.Models;
using Teste.Models;

namespace TelaClientes.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Cliente> Clientes { get; set; }

        public MainViewModel()
        {
            Clientes = new ObservableCollection<Cliente>()
            {
                new Cliente { Nome = "Luis Gustavo Mendonça", Email = "email@exemplo.com", Cidade = "Cachoeira Paulista - SP" },
                new Cliente { Nome = "Givaldo Valker Vicente", Email = "email@exemplo.com", Cidade = "Cruzeiro - SP" },
                new Cliente { Nome = "Sabrina Carpenter", Email = "email@exemplo.com", Cidade = "São José dos Campos - SP" },
                new Cliente { Nome = "Elisa Sanchez da Silva", Email = "email@exemplo.com", Cidade = "Silveiras - SP" },
                new Cliente { Nome = "Taylor Swift Braga Neves", Email = "email@exemplo.com", Cidade = "Lorena - SP" }
            };
        }
    }
}