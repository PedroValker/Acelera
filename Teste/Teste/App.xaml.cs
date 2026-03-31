using System.IO;
using System.Text;
using System.Windows;
using Teste.Repository;

namespace Teste
{
    public partial class App : Application
    {
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            string pastaProjeto = Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")
            );

            string pastaCadastro = Path.Combine(pastaProjeto, "cadastroUsers");

            if (!Directory.Exists(pastaCadastro))
            {
                Directory.CreateDirectory(pastaCadastro);
            }

            string arquivoCadastro = Path.Combine(pastaCadastro, "cadastroUsers.txt");

            var sb = new StringBuilder();

            foreach (var user in MemoriaUsuarios.Lista)
            {
                sb.AppendLine(
                    $"Nome:{user.Nome} | Email:{user.Email} | Telefone:{user.Telefone} | Senha:{user.Senha} | Data:{user.DataCriacao}"
                );
            }

            File.WriteAllText(arquivoCadastro, sb.ToString(), Encoding.UTF8);
        }
    }
}