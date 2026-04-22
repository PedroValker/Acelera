using System.Windows;
using Teste.Model;
using System.Windows.Controls;

namespace Teste.View   // 🔥 AQUI ESTÁ A CORREÇÃO
{
    public partial class CadastroProduto : UserControl
    {
        public CadastroProduto()
        {
            InitializeComponent();
        }

        private void SalvarProduto_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomeProdutoBox.Text) ||
                string.IsNullOrWhiteSpace(MarcaBox.Text) ||
                CategoriaBox.SelectedItem == null ||
                string.IsNullOrWhiteSpace(PrecoBox.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!");
                return;
            }

            Produto produto = new Produto
            {
                Nome = NomeProdutoBox.Text,
                Marca = MarcaBox.Text,
                Categoria = (CategoriaBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                Preco = decimal.Parse(PrecoBox.Text),
            };

            MessageBox.Show("Produto cadastrado com sucesso!");

            NomeProdutoBox.Clear();
            MarcaBox.Clear();
            CategoriaBox.SelectedIndex = -1;
            PrecoBox.Clear();
        }
    }
}