using System;
using System.Collections.Generic;

namespace Teste.Models
{
    public class User
    {
        public string Nome { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string Senha { get; set; } = "";
        public DateTime DataCriacao { get; set; } = DateTime.Now; // inicializa com data atual
    }

    public class Cliente
    {
        public string Nome { get; set; } = "";
        public string Email { get; set; } = "";
        // Se quiser hierarquia, descomente a linha abaixo
        // public List<Cliente> Clientes { get; set; } = new List<Cliente>();
    }

}