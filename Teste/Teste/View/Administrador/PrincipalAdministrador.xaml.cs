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
        // Variável global para guardar o nome do admin, 
        // assim podemos usar toda vez que ele clicar no botão "Início"
        private string _nomeDoAdmin;

        // 🔥 Alteramos o construtor para receber a string
        public PrincipalAdministrador(string nomeAdmin)
        {
            InitializeComponent();

            _nomeDoAdmin = nomeAdmin;

            // 1. Atualiza o texto no Menu Lateral
            NomeAdminMenu.Text = $"Olá, {_nomeDoAdmin}";

            // 2. Carrega o HomeAdministrador passando o nome pra lá também
            ConteudoPrincipal.Content = new HomeAdministrador(_nomeDoAdmin);
        }

        private void Inicio_Click(object sender, RoutedEventArgs e)
        {
            // Toda vez que clicar no Início, passa o nome de novo
            ConteudoPrincipal.Content = new HomeAdministrador(_nomeDoAdmin);
        }

        // ... (O resto dos seus cliques de botão continua igual) ...
        private void Pedidos_Click(object sender, RoutedEventArgs e)
        {
            // O código "new ();" dava erro. Deixei comentado até você criar a tela de Pedidos.
            // ConteudoPrincipal.Content = new SuaTelaDePedidosAqui();
        }

        private void Cadastrar_Click(object sender, RoutedEventArgs e)
        {
            ConteudoPrincipal.Content = new CadastroProduto();
        }

        private void Pendencias_Click(object sender, RoutedEventArgs e)
        {
            // Por enquanto está abrindo CadastroProduto, mude quando criar a tela de Pendências
           // ConteudoPrincipal.Content = new CadastroProduto();
        }
        private void Cestas_Click(object sender, RoutedEventArgs e)
        {
            // Limpa a tela central e carrega a tela de Cadastro de Cestas
            ConteudoPrincipal.Content = new CadastroCesta();
        }
        private void Estatisticas_Click(object sender, RoutedEventArgs e)
        {
            // Por enquanto está abrindo CadastroProduto, mude quando criar a tela de Estatísticas
           // ConteudoPrincipal.Content = new CadastroProduto();
        }

        private void Clientes_Click(object sender, RoutedEventArgs e)
        {
            // Por enquanto está abrindo CadastroProduto, mude quando criar a tela de Clientes
            //ConteudoPrincipal.Content = new CadastroProduto();
        }
    }
}