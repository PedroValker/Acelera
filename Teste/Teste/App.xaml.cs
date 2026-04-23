using System.IO;
using System.Text;
using System.Windows;
using Teste.Repository;

namespace Teste
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 🔥 Carrega usuários
            UserRepository repo = new UserRepository();
            repo.CarregarDoArquivo();

          
            // 🔥 Carrega produtos
            ProdutoRepository repoProdutos = new ProdutoRepository();
            repoProdutos.CarregarDoArquivo();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                string pastaProjeto = Path.GetFullPath(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));

                SalvarUsuarios(pastaProjeto);
                SalvarProdutos(pastaProjeto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar dados: " + ex.Message);
            }

            base.OnExit(e);
        }

        private void SalvarUsuarios(string pastaProjeto)
        {
            string pasta = Path.Combine(pastaProjeto, "cadastroUsers");

            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            string arquivo = Path.Combine(pasta, "cadastroUsers.txt");

            List<string> linhas = new List<string>();

            foreach (var user in MemoriaUsuarios.Lista)
            {
                linhas.Add($"Id:{user.Id} | Nome:{user.Nome} | Email:{user.Email} | Telefone:{user.Telefone} | Senha:{user.Senha} | Data:{user.DataCriacao}");
            }

            File.WriteAllLines(arquivo, linhas, Encoding.UTF8);
        }

        private void SalvarProdutos(string pastaProjeto)
        {
            string pasta = Path.Combine(pastaProjeto, "cadastroProdutos");

            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            string arquivo = Path.Combine(pasta, "produtos.txt");

            List<string> linhas = new List<string>();

            foreach (var p in MemoriaProdutos.Lista)
            {
                linhas.Add($"Nome:{p.Nome} | Marca:{p.Marca} | Categoria:{p.Categoria} | Preco:{p.Preco} | Peso:{p.Peso}");
            }

            File.WriteAllLines(arquivo, linhas, Encoding.UTF8);
        }
    }
}