using System.Windows;

namespace Teste
{
    public partial class CadastroProdutos : Window
    {
        public CadastroProdutos()
        {
            InitializeComponent();
        }

        private void SalvarProduto_Click(object sender, RoutedEventArgs e)
        {
            // Validação simples
            if (string.IsNullOrWhiteSpace(NomeProdutoBox.Text) ||
                string.IsNullOrWhiteSpace(MarcaBox.Text) ||
                CategoriaBox.SelectedItem == null ||
                string.IsNullOrWhiteSpace(PrecoBox.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!");
                return;
            }

            // Criando objeto
            Produto produto = new Produto
            {
                Nome = NomeProdutoBox.Text,
                Marca = MarcaBox.Text,
                Categoria = (CategoriaBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                Preco = decimal.Parse(PrecoBox.Text),
                Descricao = DescricaoBox.Text
            };

            MessageBox.Show("Produto cadastrado com sucesso!");

            // Limpar campos
            NomeProdutoBox.Clear();
            MarcaBox.Clear();
            CategoriaBox.SelectedIndex = -1;
            PrecoBox.Clear();
            DescricaoBox.Clear();
        }
    }

    public class Produto
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
    }
}