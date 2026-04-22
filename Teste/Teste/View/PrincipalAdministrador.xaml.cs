using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Teste.View
{

    public partial class PrincipalAdministrador : Window
    {
        public PrincipalAdministrador()
        {
            InitializeComponent();
        }
        

    private void Pedidos_Click(object sender, RoutedEventArgs e)
        {
            ConteudoPrincipal.Content = new ();
        }

        private void Cadastrar_Click(object sender, RoutedEventArgs e)
        {
            ConteudoPrincipal.Content = new CadastroProduto();
        }

        private void Pendencias_Click(object sender, RoutedEventArgs e)
        {
            ConteudoPrincipal.Content = new CadastroProduto();
        }

        private void Estatisticas_Click(object sender, RoutedEventArgs e)
        {
            ConteudoPrincipal.Content = new CadastroProduto();
        }

        private void Clientes_Click(object sender, RoutedEventArgs e)
        {
            ConteudoPrincipal.Content = new CadastroProduto();
        }
     
    }
}
