using System.Windows;

namespace Teste.View
{
    public partial class TelaPrincipalCliente : Window
    {
        public TelaPrincipalCliente(string nome)
        {
            InitializeComponent();

            // 🔥 MOSTRA O NOME NA TELA
            NomeUsuarioText.Text = $"Olá, {nome}";
        }

        public TelaPrincipalCliente()
        {
            InitializeComponent();
        }
    }
}