using Teste.ViewModel;
using System;
using System.Windows;

namespace Teste
{
    public partial class MainWindow : Window
    {
        CadastroViewModel vm = new CadastroViewModel();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CriarConta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                vm.CriarConta(
                    NomeBox.Text,
                    EmailBox.Text,
                    TelefoneBox.Text,
                    SenhaBox.Password,
                    ConfirmarSenhaBox.Password
                );

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
                MessageBox.Show(ex.Message,
                                "Erro",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }
}