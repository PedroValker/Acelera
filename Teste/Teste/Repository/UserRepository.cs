using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Models;

namespace Teste.Repository
{
    class UserRepository
    {
      
        public void Salvar(User user)
        {
            string pastaProjeto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));

            string pastaCadastro = Path.Combine(pastaProjeto, "cadastroUsers");

            if (!Directory.Exists(pastaCadastro))
            {
                Directory.CreateDirectory(pastaCadastro);
            }

            string arquivoCadastro = Path.Combine(pastaCadastro, "cadastroUsers.txt");

            string dadosCadastro =
                $"Nome:{user.Nome} | Email:{user.Email} | Telefone:{user.Telefone} | Senha:{user.Senha} | Data:{user.DataCriacao}\n";

            File.AppendAllText(arquivoCadastro, dadosCadastro, Encoding.UTF8);
        }

        // Verifica se a senha já existe no arquivo de cadastro
        public bool SenhaExiste(string senha)
        {
            string pastaProjeto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
            string pastaCadastro = Path.Combine(pastaProjeto, "cadastroUsers");
            string arquivoCadastro = Path.Combine(pastaCadastro, "cadastroUsers.txt");

            if (!File.Exists(arquivoCadastro))
                return false;

            var linhas = File.ReadAllLines(arquivoCadastro);

            foreach (var linha in linhas)
            {
                var partes = linha.Split('|');
                if (partes.Length < 4) continue;

                string senhaArquivo = partes[3].Replace("Senha:", "").Trim();
                if (senhaArquivo == senha)
                    return true;
            }

            return false;
        }
        public User BuscarPorEmail(string email)
        {
            string pastaProjeto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));

            string pastaCadastro = Path.Combine(pastaProjeto, "cadastroUsers");

            string arquivoCadastro = Path.Combine(pastaCadastro, "cadastroUsers.txt");

            if (!File.Exists(arquivoCadastro))
            {
                return null;
            }

            var linhas = File.ReadAllLines(arquivoCadastro);

            foreach (var linha in linhas)
            {
                var partes = linha.Split('|');

                string nome = partes[0].Replace("Nome:", "").Trim();
                string emailArquivo = partes[1].Replace("Email:", "").Trim();
                string telefone = partes[2].Replace("Telefone:", "").Trim();
                string senha = partes[3].Replace("Senha:", "").Trim();

                if (emailArquivo == email)
                {
                    return new User
                    {
                        Nome = nome,
                        Email = emailArquivo,
                        Telefone = telefone,
                        Senha = senha
                    };
                }
            }

            return null;
        }
    }
}
