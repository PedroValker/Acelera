using System.Windows.Controls;

namespace Teste.View
{
    /// <summary>
    /// Lógica interna para HomeAdministrador.xaml
    /// </summary>
    public partial class HomeAdministrador : UserControl
    {
        public HomeAdministrador(string nomeAdmin)
        {
            InitializeComponent();

            // Atualiza o texto grandão da tela principal
            BoasVindasTexto.Text = $"Bem-vindo de volta, {nomeAdmin}! Aqui está o resumo de hoje.";
        }
    }
}