using System.Windows;
using Teste.Model;

namespace Teste.View
{
    public partial class DetalhesCestaWindow : Window
    {
        // O construtor recebe a cesta que foi clicada
        public DetalhesCestaWindow(Cesta cesta)
        {
            InitializeComponent();

            // Altera o título para o nome da cesta clicada
            TituloCesta.Text = $"Cesta: {cesta.Nome}";

            // Preenche a tabela com os produtos
            ListaProdutosCesta.ItemsSource = cesta.Itens;
        }

        private void Fechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Fecha a janelinha
        }
    }
}