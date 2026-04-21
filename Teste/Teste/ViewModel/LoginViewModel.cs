using System;
using Teste.Model;
using Teste.Repository;

namespace Teste.ViewModel
{
    public class LoginViewModel
    {
        public User FazerLogin(string email, string senha)
        {
            UserRepository repo = new UserRepository();

            // ❌ APAGUE OU COMENTE A LINHA ABAIXO:
            // repo.CarregarDoArquivo(); 

            // Busca direto na memória (onde o novo usuário acabou de ser cadastrado)
            User user = repo.BuscarPorEmail(email);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            if (user.Senha != senha)
                throw new Exception("Senha incorreta");

            return user;
        }
    }
}