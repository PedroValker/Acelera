using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CadastroTela
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CriarConta_Click(object sender, RoutedEventArgs e)
        {
            if (SenhaBox.Password != ConfirmarSenhaBox.Password)
            {
                MessageBox.Show("As senhas não coincidem!",
                                "Erro",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }

            try
            {
                // Obtém o caminho da pasta Documentos do usuário
                string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Define a pasta cadastroUsers dentro de Documentos
                string pastaCadastro = System.IO.Path.Combine(documentosPath, "cadastroUsers");

                // Cria a pasta se não existir
                if (!System.IO.Directory.Exists(pastaCadastro))
                {
                    System.IO.Directory.CreateDirectory(pastaCadastro);
                }

                // Caminho completo do arquivo cadastroUsers.txt
                string arquivoCadastro = System.IO.Path.Combine(pastaCadastro, "cadastroUsers.txt");

                // Dados para salvar (exemplo: Nome, Email, Telefone)
                // Como você não tem TextBox nomeados para esses campos no código atual, 
                // vou assumir que você adicionará nomes depois, aqui só demonstro como salvar.
                // Para esse exemplo, só salvaremos a senha (não recomendado para senhas reais!)
                // Você deve adaptar para salvar os campos corretos.

                string dadosCadastro = $"Nome:{NomeBox.Text} | Email:{EmailBox} | TeSenha:{SenhaBox.Password} | Confirmar Senha: {ConfirmarSenhaBox.Password} | Data: {DateTime.Now}\n";

                // Adiciona os dados no final do arquivo
                System.IO.File.AppendAllText(arquivoCadastro, dadosCadastro, Encoding.UTF8);

                MessageBox.Show("Conta criada com sucesso!",
                                "Sucesso",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                NomeBox.Text = "";
                EmailBox.Text = "";
                TelefoneBox.Text = "";
                SenhaBox.Password = "";
                ConfirmarSenhaBox.Password = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar cadastro: {ex.Message}",
                                "Erro",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }
}