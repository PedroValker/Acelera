using System;
using Teste.Model;
using Teste.Repository;

namespace Teste.ViewModel
{
    public class LoginViewModel
    {
        public User FazerLogin(string email, string senha)
        {
            // Instancia o repositório
            UserRepository repo = new UserRepository();

            // Garante que a memória está carregada
            // Só chama uma vez no início do programa (pode colocar no App.xaml.cs também)
            repo.CarregarDoArquivo();

            // Busca na memória
            User user = repo.BuscarPorEmail(email);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            if (user.Senha != senha)
                throw new Exception("Senha incorreta");

            return user;
        }
    }
}