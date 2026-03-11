using System;
using System.Windows;
using System.Windows.Input;
using Teste.Models;
using Teste.ViewModel;

namespace Teste
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        // BOTÃO ENTRAR
        private void BotaoEntrar_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailBox.Text;
            string senha = SenhaBox.Password;

            // Validação simples
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.",
                                "Aviso",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            try
            {
                LoginViewModel vm = new LoginViewModel();

                User usuario = vm.FazerLogin(email, senha);

                MessageBox.Show($"Login realizado com sucesso! Bem-vindo, {usuario.Nome}.",
                                "Sucesso",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                // Precisar se alterado: Adicionar a tela do usuario logado
                MainWindow telaPrincipal = new MainWindow();
                telaPrincipal.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Erro no Login",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        // LINK PARA IR PARA CADASTRO
        private void AbrirCadastro_Click(object sender, MouseButtonEventArgs e)
        {
            MainWindow cadastro = new MainWindow();
            cadastro.Show();
            this.Close();
        }
    }
}