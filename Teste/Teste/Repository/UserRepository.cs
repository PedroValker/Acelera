using System;
using System.Linq;
using Teste.Model;
using System.IO;
using System.Collections.Generic;

namespace Teste.Repository
{
    class UserRepository
    {
        // Salva usuário na memória, mas só se passar as validações
        public void CarregarDoArquivo()
        {
            MemoriaUsuarios.Lista.Clear(); // 🔥 evita duplicação

            // Mude esta linha no seu UserRepository.cs:
            string pastaProjeto = Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\") // <-- Coloque 3 vezes o ..\ aqui também!
    
            );

            string caminho = Path.Combine(pastaProjeto, "cadastroUsers", "cadastroUsers.txt");

            if (!File.Exists(caminho))
                return;

            var linhas = File.ReadAllLines(caminho);

            foreach (var linha in linhas)
            {
                var partes = linha.Split('|');

                if (partes.Length < 5)
                    continue;

                if (!int.TryParse(partes[0].Replace("Id:", "").Trim(), out int id))
                    continue;

                var user = new User(id)
                {
                    Nome = partes[1].Replace("Nome:", "").Trim(),
                    Email = partes[2].Replace("Email:", "").Trim(),
                    Telefone = partes[3].Replace("Telefone:", "").Trim(),
                    Senha = partes[4].Replace("Senha:", "").Trim()
                };

                MemoriaUsuarios.Lista.Add(user);
            }
        }
        public bool Salvar(User user, out string mensagemErro)
        {
            mensagemErro = "";

            // Validações básicas
            if (string.IsNullOrWhiteSpace(user.Nome) ||
                string.IsNullOrWhiteSpace(user.Email) ||
                string.IsNullOrWhiteSpace(user.Senha))
            {
                mensagemErro = "Nome, Email e Senha são obrigatórios.";
                return false;
            }

            // Verifica se email já existe
            if (BuscarPorEmail(user.Email) != null)
            {
                mensagemErro = "Este email já está cadastrado.";
                return false;
            }

            // Verifica se senha já existe
            if (SenhaExiste(user.Senha))
            {
                mensagemErro = "Esta senha já está em uso, escolha outra.";
                return false;
            }

            // Se passou tudo, adiciona na memória
            MemoriaUsuarios.Lista.Add(user);
            return true;
        }

        public bool SenhaExiste(string senha)
        {
            return MemoriaUsuarios.Lista.Any(u => u.Senha == senha);
        }

        public User BuscarPorEmail(string email)
        {
            return MemoriaUsuarios.Lista
                .FirstOrDefault(u => u.Email == email);
        }
    }
}