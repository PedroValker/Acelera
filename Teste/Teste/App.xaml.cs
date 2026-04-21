using System.IO;
using System.Text;
using System.Windows;
using Teste.Repository;
using static System.Net.WebRequestMethods;

namespace Teste
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 🔥 CARREGA OS USUÁRIOS AO ABRIR O SISTEMA
            UserRepository repo = new UserRepository();
            repo.CarregarDoArquivo();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                // 1. Sobe 3 níveis para chegar na raiz do projeto (onde estão os fontes)
                string pastaProjeto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
                string pastaCadastro = Path.Combine(pastaProjeto, "cadastroUsers");

                if (!Directory.Exists(pastaCadastro))
                    Directory.CreateDirectory(pastaCadastro);

                string arquivoCadastro = Path.Combine(pastaCadastro, "cadastroUsers.txt");

                // 2. Criamos uma lista de strings diretamente
                List<string> linhas = new List<string>();
                foreach (var user in MemoriaUsuarios.Lista)
                {
                    linhas.Add($"Id:{user.Id} | Nome:{user.Nome} | Email:{user.Email} | Telefone:{user.Telefone} | Senha:{user.Senha} | Data:{user.DataCriacao}");
                }

                // 3. Salva tudo de uma vez
                System.IO.File.WriteAllLines(arquivoCadastro, linhas, Encoding.UTF8);
                // TIRE O COMENTÁRIO DAQUI (Para ter certeza que passou por aqui)
                MessageBox.Show($"Sucesso! {linhas.Count} usuários foram salvos antes de sair!");
            }
            catch (Exception ex)
            {
                // TIRE O COMENTÁRIO DAQUI (Para ver se o Windows está bloqueando)
                MessageBox.Show("Erro ao salvar no fechamento: " + ex.Message);
            }

            base.OnExit(e);
        }
    }
}// 3. Salva tudo de uma vez
