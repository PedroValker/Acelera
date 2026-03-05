using System;
using Teste.Models;
using Teste.Repository;

namespace Teste.ViewModel
{
    public class CadastroViewModel
    {
        public void CriarConta(string nome, string email, string telefone, string senha, string confirmarSenha)
        {
            if (senha != confirmarSenha)
            {
                throw new Exception("As senhas não coincidem!");
            }

            User usuario = new User()
            {
                Nome = nome,
                Email = email,
                Telefone = telefone,
                Senha = senha,
                DataCriacao = DateTime.Now
            };

            UserRepository repo = new UserRepository();
            repo.Salvar(usuario);
        }
    }
}