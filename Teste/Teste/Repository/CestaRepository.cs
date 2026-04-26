using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Teste.Model;

namespace Teste.Repository
{
    public class CestaRepository
    {
        private string ObterCaminhoArquivo()
        {
            string pastaProjeto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            return Path.Combine(pastaProjeto, "Dados", "cestas.txt");
        }

        public bool Salvar(Cesta cesta, out string mensagemErro)
        {
            mensagemErro = "";
            try
            {
                string caminho = ObterCaminhoArquivo();
                Directory.CreateDirectory(Path.GetDirectoryName(caminho));

                string nomesProdutos = string.Join(",", cesta.Itens.Select(p => p.Nome));

                // 🔥 Salvando no novo formato "Chave:Valor |"
                string linha = $"ID:{cesta.Id} |Nome:{cesta.Nome} |Preco:{cesta.Preco} |Produtos:{nomesProdutos}\n";

                File.AppendAllText(caminho, linha);

                MemoriaCestas.Lista.Add(cesta);
                return true;
            }
            catch (Exception ex)
            {
                mensagemErro = "Erro ao salvar cesta: " + ex.Message;
                return false;
            }
        }

        public void AtualizarArquivoTxt()
        {
            try
            {
                string caminho = ObterCaminhoArquivo();
                Directory.CreateDirectory(Path.GetDirectoryName(caminho));

                List<string> linhasParaSalvar = new List<string>();

                foreach (var cesta in MemoriaCestas.Lista)
                {
                    string nomesProdutos = string.Join(",", cesta.Itens.Select(p => p.Nome));

                    // 🔥 Atualizando no novo formato também
                    string linha = $"ID:{cesta.Id} |Nome:{cesta.Nome} |Preco:{cesta.Preco} |Produtos:{nomesProdutos}";
                    linhasParaSalvar.Add(linha);
                }

                File.WriteAllLines(caminho, linhasParaSalvar);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar cestas TXT: " + ex.Message);
            }
        }

        public void CarregarDoArquivo()
        {
            MemoriaCestas.Lista.Clear();
            string caminho = ObterCaminhoArquivo();

            if (!File.Exists(caminho)) return;

            var linhas = File.ReadAllLines(caminho);

            foreach (var linha in linhas)
            {
                var partes = linha.Split('|');

                if (partes.Length < 4) continue;

                // 🔥 LIMPANDO AS TAGS ANTES DE LER OS VALORES (Igual no UserRepository)
                string idLimpo = partes[0].Replace("ID:", "").Trim();
                string nomeLimpo = partes[1].Replace("Nome:", "").Trim();
                string precoLimpo = partes[2].Replace("Preco:", "").Trim();
                string produtosLimpos = partes[3].Replace("Produtos:", "").Trim();

                // Evita erro se o ID não for um número válido
                if (!int.TryParse(idLimpo, out int id))
                    continue;

                Cesta c = new Cesta(id)
                {
                    Nome = nomeLimpo,
                    Preco = decimal.Parse(precoLimpo)
                };

                // Puxa os produtos limpinhos
                string[] nomesProdutos = produtosLimpos.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var nome in nomesProdutos)
                {
                    Produto prodEncontrado = MemoriaProdutos.Lista.FirstOrDefault(p => p.Nome == nome.Trim());
                    if (prodEncontrado != null)
                    {
                        c.Itens.Add(prodEncontrado);
                    }
                }

                MemoriaCestas.Lista.Add(c);
            }
        }
    }
}