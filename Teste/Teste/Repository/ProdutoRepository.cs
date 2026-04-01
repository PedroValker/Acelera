using System;
using System.IO;
using System.Linq;
using Teste.Models;

namespace Teste.Repository
{
    public class ProdutoRepository
    {
        // Retorna o caminho completo do arquivo de produtos
        private string ObterCaminho()
        {
            string pastaProjeto = Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")
            );

            // Pasta e arquivo
            return Path.Combine(pastaProjeto, "cadastroProdutos", "produtos.txt");
        }

        // Carrega produtos do arquivo para memória
        public void CarregarDoArquivo()
        {
            string caminho = ObterCaminho();

            // Cria pasta se não existir
            string pasta = Path.GetDirectoryName(caminho)!;
            Directory.CreateDirectory(pasta);

            // Se o arquivo não existe, nada a fazer
            if (!File.Exists(caminho))
                return;

            var linhas = File.ReadAllLines(caminho);

            foreach (var linha in linhas)
            {
                var partes = linha.Split('|');

                // Ignora linhas inválidas
                if (partes.Length < 4)
                    continue;

                // Converte preço com segurança
                decimal preco = decimal.TryParse(partes[3].Replace("Preco:", "").Trim(), out var p) ? p : 0m;

                MemoriaProdutos.Lista.Add(new Produto
                {
                    Nome = partes[0].Replace("Nome:", "").Trim(),
                    Marca = partes[1].Replace("Marca:", "").Trim(),
                    Categoria = partes[2].Replace("Categoria:", "").Trim(),
                    Preco = preco
                });
            }
        }

        // Salva produto na memória e no arquivo
        public bool Salvar(Produto produto, out string erro)
        {
            erro = "";

            // Validações básicas
            if (string.IsNullOrWhiteSpace(produto.Nome) ||
                string.IsNullOrWhiteSpace(produto.Marca) ||
                string.IsNullOrWhiteSpace(produto.Categoria))
            {
                erro = "Preencha todos os campos obrigatórios.";
                return false;
            }

            // Evita duplicidade pelo nome
            if (MemoriaProdutos.Lista.Any(p => p.Nome == produto.Nome))
            {
                erro = "Produto já cadastrado.";
                return false;
            }

            // Adiciona na memória
            MemoriaProdutos.Lista.Add(produto);

            // Salva no arquivo
            SalvarNoArquivo(produto);

            return true;
        }

        // Salva um produto no arquivo
        private void SalvarNoArquivo(Produto produto)
        {
            string caminho = ObterCaminho();

            // Cria pasta caso não exista
            string pasta = Path.GetDirectoryName(caminho)!;
            Directory.CreateDirectory(pasta);

            // Linha formatada
            string linha = $"Nome:{produto.Nome} | Marca:{produto.Marca} | Categoria:{produto.Categoria} | Preco:{produto.Preco}";

            File.AppendAllText(caminho, linha + Environment.NewLine);
        }
    }
}