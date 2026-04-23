using System.Windows;
using System.Windows.Controls;
using Teste.Model;
using Teste.Repository;

namespace Teste.View   // 🔥 AQUI ESTÁ A CORREÇÃO
{
    public partial class CadastroProduto : UserControl
    {
        public CadastroProduto()
        {
            InitializeComponent();

            ListaProdutos.ItemsSource = MemoriaProdutos.Lista;
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
                Peso = PesoBox.Text
            };

            ProdutoRepository repo = new ProdutoRepository();

            if (!repo.Salvar(produto, out string erro))
            {
                MessageBox.Show(erro);
                return;
            }

            // 🔥 Atualiza a lista (refresca visual)
            ListaProdutos.ItemsSource = null;
            ListaProdutos.ItemsSource = MemoriaProdutos.Lista;

            MessageBox.Show("Produto cadastrado com sucesso!");

            NomeProdutoBox.Clear();
            MarcaBox.Clear();
            CategoriaBox.SelectedIndex = -1;
        }
    }
}