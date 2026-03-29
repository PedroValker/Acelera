using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Teste.Repository;
using Teste.ViewModel;

namespace Teste
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CriarConta_Click(object sender, RoutedEventArgs e)
        {
            string nome = NomeBox.Text;
            string email = EmailBox.Text;
            string telefone = TelefoneBox.Text;
            string senha = SenhaBox.Password;
            string confirmarSenha = ConfirmarSenhaBox.Password;

            if (!EmailValido(email))
            {
                MessageBox.Show("Por favor, informe um e-mail válido.");
                return;
            }

            if (!TelefoneValido(telefone))
            {
                MessageBox.Show("Por favor, informe um número de telefone válido com 10 ou 11 dígitos.");
                return;
            }

            UserRepository repo = new UserRepository();
            if (repo.SenhaExiste(senha))
            {
                MessageBox.Show("Essa senha já foi usada. Por favor, escolha outra.");
                return;
            }

            try
            {
                CadastroViewModel vm = new CadastroViewModel();
                vm.CriarConta(nome, email, telefone, senha, confirmarSenha);

                MessageBox.Show("Conta criada com sucesso!");

                Login login = new Login();
                login.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool EmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private bool TelefoneValido(string telefone)
        {
            return telefone.Length == 10 || telefone.Length == 11;
        }

        private void TelefoneBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Entrar_Click(object sender, RoutedEventArgs e)
        {
            // Abre a janela de Login
            Login loginWindow = new Login();
            loginWindow.Show();

            // Fecha a janela atual (Cadastro)
            this.Close();
        }
    }
}
