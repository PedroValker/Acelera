using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Teste.Model;
using Teste.Repository;

namespace Teste.View
{
    public partial class CadastroCesta : UserControl
    {
        private Cesta _cestaEmEdicao = null;

        // Lista temporária que armazena os produtos enquanto a cesta está sendo criada/editada
        private List<Produto> _itensDaCestaAtual = new List<Produto>();

        public CadastroCesta()
        {
            InitializeComponent();

            // Preenche o ComboBox com todos os produtos do sistema
            ProdutosComboBox.ItemsSource = MemoriaProdutos.Lista;

            AtualizarListaItensAtuais();
            AtualizarListaCestas();
        }

        // 🔥 1. ADICIONA PRODUTO NA CESTA ATUAL
        private void AdicionarItem_Click(object sender, RoutedEventArgs e)
        {
            Produto produtoSelecionado = ProdutosComboBox.SelectedItem as Produto;

            if (produtoSelecionado != null)
            {
                _itensDaCestaAtual.Add(produtoSelecionado);
                AtualizarListaItensAtuais();
            }
            else
            {
                MessageBox.Show("Selecione um produto primeiro!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // 🔥 2. REMOVE PRODUTO DA CESTA ATUAL
        private void RemoverItemDaCesta_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Produto produtoClicado = btn.DataContext as Produto;

            if (produtoClicado != null)
            {
                _itensDaCestaAtual.Remove(produtoClicado);
                AtualizarListaItensAtuais();
            }
        }

        // 🔥 3. SALVAR (NOVA OU EDIÇÃO)
        private void SalvarCesta_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomeCestaBox.Text) || string.IsNullOrWhiteSpace(PrecoCestaBox.Text))
            {
                MessageBox.Show("Preencha o nome e o preço da cesta!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_itensDaCestaAtual.Count == 0)
            {
                MessageBox.Show("A cesta precisa ter pelo menos um produto!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            CestaRepository repo = new CestaRepository();

            if (_cestaEmEdicao != null)
            {
                // MODO EDIÇÃO
                _cestaEmEdicao.Nome = NomeCestaBox.Text;
                _cestaEmEdicao.Preco = decimal.Parse(PrecoCestaBox.Text);

                // Copia a lista temporária para a cesta sendo editada
                _cestaEmEdicao.Itens = new List<Produto>(_itensDaCestaAtual);

                repo.AtualizarArquivoTxt();
                MessageBox.Show("Cesta atualizada com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                _cestaEmEdicao = null;
            }
            else
            {
                // MODO NOVA CESTA
                Cesta novaCesta = new Cesta
                {
                    Nome = NomeCestaBox.Text,
                    Preco = decimal.Parse(PrecoCestaBox.Text),
                    Itens = new List<Produto>(_itensDaCestaAtual)
                };

                if (!repo.Salvar(novaCesta, out string erro))
                {
                    MessageBox.Show(erro, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBox.Show("Cesta criada com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            LimparCampos();
            AtualizarListaCestas();
        }

        // 🔥 4. BOTÃO EDITAR CESTA DA TABELA
        private void EditarCesta_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Cesta cestaClicada = btn.DataContext as Cesta;

            if (cestaClicada != null)
            {
                _cestaEmEdicao = cestaClicada;

                NomeCestaBox.Text = cestaClicada.Nome;
                PrecoCestaBox.Text = cestaClicada.Preco.ToString();

                // Copia os itens da cesta cadastrada para a lista temporária da tela
                _itensDaCestaAtual = new List<Produto>(cestaClicada.Itens);

                AtualizarListaItensAtuais();
            }
        }

        // 🔥 5. BOTÃO EXCLUIR CESTA
        private void ExcluirCesta_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Cesta cestaClicada = btn.DataContext as Cesta;

            if (cestaClicada != null)
            {
                MessageBoxResult resposta = MessageBox.Show($"Deseja excluir a '{cestaClicada.Nome}'?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resposta == MessageBoxResult.Yes)
                {
                    MemoriaCestas.Lista.Remove(cestaClicada);

                    CestaRepository repo = new CestaRepository();
                    repo.AtualizarArquivoTxt();

                    AtualizarListaCestas();

                    if (_cestaEmEdicao == cestaClicada)
                    {
                        _cestaEmEdicao = null;
                        LimparCampos();
                    }
                }
            }
        }

        // Métodos auxiliares de atualização de tela
        private void AtualizarListaItensAtuais()
        {
            ListaItensAtuais.ItemsSource = null;
            ListaItensAtuais.ItemsSource = _itensDaCestaAtual;
        }

        private void AtualizarListaCestas()
        {
            ListaCestas.ItemsSource = null;
            ListaCestas.ItemsSource = MemoriaCestas.Lista;
        }
        // 🔥 EVENTO NOVO: CLIQUE NO BOTÃO VER ITENS
        private void VerItens_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Cesta cestaClicada = btn.DataContext as Cesta;

            if (cestaClicada != null)
            {
                // Instancia a nova janela passando a cesta selecionada
                DetalhesCestaWindow popup = new DetalhesCestaWindow(cestaClicada);

                // ShowDialog() faz com que a janela abra como um "Popup" 
                // bloqueando a tela de trás até o usuário fechá-la
                popup.ShowDialog();
            }
        }
        private void LimparCampos()
        {
            NomeCestaBox.Clear();
            PrecoCestaBox.Clear();
            ProdutosComboBox.SelectedIndex = -1;
            _itensDaCestaAtual.Clear();
            AtualizarListaItensAtuais();
        }
    }
}