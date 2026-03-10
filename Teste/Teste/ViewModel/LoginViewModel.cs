using System;
using Teste.Models;
using Teste.Repository;

namespace Teste.ViewModel
{
    public class LoginViewModel
    {
        public User FazerLogin(string email, string senha)
        {
            UserRepository repo = new UserRepository();

            User usuario = repo.BuscarPorEmail(email);

            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            if (usuario.Senha != senha)
            {
                throw new Exception("Senha incorreta!");
            }

            return usuario;
        }
    }
}