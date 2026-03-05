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
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string pastaCadastro = Path.Combine(documentosPath, "cadastroUsers");

            if (!Directory.Exists(pastaCadastro))
            {
                Directory.CreateDirectory(pastaCadastro);
            }

            string arquivoCadastro = Path.Combine(pastaCadastro, "cadastroUsers.txt");

            string dadosCadastro =
                $"Nome:{user.Nome} | Email:{user.Email} | Telefone:{user.Telefone} | Senha:{user.Senha} | Data:{user.DataCriacao}\n";

            File.AppendAllText(arquivoCadastro, dadosCadastro, Encoding.UTF8);
        }
    }
}
