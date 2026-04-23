using System;
using System.IO;
using System.Linq;
using Teste.Model;

namespace Teste.Repository
{
    public class ProdutoRepository
    {
        private string ObterCaminho()
        {
            string pastaProjeto = Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\")
            );

            return Path.Combine(pastaProjeto, "cadastroProdutos", "produtos.txt");
        }

        // 🔥 CARREGAR DO ARQUIVO
        public void CarregarDoArquivo()
        {
            string caminho = ObterCaminho();

            string pasta = Path.GetDirectoryName(caminho)!;
            Directory.CreateDirectory(pasta);

            if (!File.Exists(caminho))
                return;

            MemoriaProdutos.Lista.Clear();

            var linhas = File.ReadAllLines(caminho);

            foreach (var linha in linhas)
            {
                var partes = linha.Split('|');

                if (partes.Length < 5)
                    continue;

                decimal preco = decimal.TryParse(
                    partes[3].Replace("Preco:", "").Trim(),
                    out var p) ? p : 0m;

                // 🔥 PESO COMO STRING
                string peso = partes[4].Replace("Peso:", "").Trim();

                MemoriaProdutos.Lista.Add(new Produto
                {
                    Nome = partes[0].Replace("Nome:", "").Trim(),
                    Marca = partes[1].Replace("Marca:", "").Trim(),
                    Categoria = partes[2].Replace("Categoria:", "").Trim(),
                    Preco = preco,
                    Peso = peso
                });
            }
        } // 🔥 FECHAMENTO QUE FALTAVA

        // 🔥 SALVAR NA MEMÓRIA
        public bool Salvar(Produto produto, out string erro)
        {
            erro = "";

            if (string.IsNullOrWhiteSpace(produto.Nome) ||
                string.IsNullOrWhiteSpace(produto.Marca) ||
                string.IsNullOrWhiteSpace(produto.Categoria))
            {
                erro = "Preencha todos os campos obrigatórios.";
                return false;
            }

            if (MemoriaProdutos.Lista.Any(p =>
                p.Nome.Trim().ToLower() == produto.Nome.Trim().ToLower()))
            {
                erro = "Produto já cadastrado.";
                return false;
            }

            MemoriaProdutos.Lista.Add(produto);

            return true;
        }

        // 🔥 SALVAR TUDO NO FINAL
        public void SalvarTudo()
        {
            string caminho = ObterCaminho();

            string pasta = Path.GetDirectoryName(caminho)!;
            Directory.CreateDirectory(pasta);

            var linhas = MemoriaProdutos.Lista.Select(p =>
                $"Nome:{p.Nome} | Marca:{p.Marca} | Categoria:{p.Categoria} | Preco:{p.Preco} | Peso:{p.Peso}");

            File.WriteAllLines(caminho, linhas);
        }
    }
}