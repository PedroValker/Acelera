using System;
using System.Windows;
using System.Windows.Input;
using Teste.ViewModel;
using Teste.Models;

namespace Teste
{
    public partial class Login : Window
    {
        private bool senhaVisivel = false;

        public Login()
        {
            InitializeComponent();
        }

        private void ToggleSenha_Click(object sender, RoutedEventArgs e)
        {
            if (senhaVisivel)
            {
                SenhaBox.Password = SenhaVisivelBox.Text;
                SenhaBox.Visibility = Visibility.Visible;
                SenhaVisivelBox.Visibility = Visibility.Collapsed;

                BotaoSenha.Content = "Ver senha";
            }
            else
            {
                SenhaVisivelBox.Text = SenhaBox.Password;
                SenhaVisivelBox.Visibility = Visibility.Visible;
                SenhaBox.Visibility = Visibility.Collapsed;

                BotaoSenha.Content = "Esconder senha";
            }

            senhaVisivel = !senhaVisivel;
        }

        private void SenhaBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SenhaPlaceholder.Visibility = string.IsNullOrEmpty(SenhaBox.Password)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void SenhaVisivelBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SenhaPlaceholder.Visibility = string.IsNullOrEmpty(SenhaVisivelBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void BotaoEntrar_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailBox.Text;
            string senha = senhaVisivel ? SenhaVisivelBox.Text : SenhaBox.Password;

            try
            {
                LoginViewModel vm = new LoginViewModel();
                User user = vm.FazerLogin(email, senha);

                MessageBox.Show($"Bem-vindo, {user.Nome}!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AbrirCadastro_Click(object sender, MouseButtonEventArgs e)
        {
            MainWindow cadastro = new MainWindow();
            cadastro.Show();

            this.Close();
        }
    }
}