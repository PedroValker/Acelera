using System.Collections.ObjectModel;
using TelaClientes;
using Teste.Models;

namespace TelaClientes.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Cliente> Clientes { get; set; }

        public MainViewModel()
        {
         
        }
    }
}