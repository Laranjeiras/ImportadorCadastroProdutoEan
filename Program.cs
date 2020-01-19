using ImportadorCadastroEan.Data;
using ImportadorCadastroEan.Modelos;
using System;
using System.Diagnostics;
using System.IO;

namespace ImportadorCadastroEan
{
    class Program
    {
        static void Main(string[] args)
        {
            var contexto = new EFContext();

            // localCsv = informar a path do arquivo csv
            var localCsv = ConfiguracaoPersitencia.LocalArquivoCsv;
            StreamReader stream = new StreamReader(localCsv);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var context = new EFContext();
            string linha = null;
            int i = 0;
            while ((linha = stream.ReadLine()) != null)
            {
                i++;
                string[] coluna = linha.Split(',');
                    
                if (coluna.Length == 17)
                {
                    var produto = new Produto();
                    produto.Gtin = Produto.RemoverAspas(coluna[0]);
                    produto.DescricaoNormalizada = Produto.RemoverAspas(coluna[1]);
                    produto.DescricaoUpper = Produto.RemoverAspas(coluna[2]);
                    produto.DescricaoAcento = Produto.RemoverAspas(coluna[3]);
                    produto.Peso = Produto.RemoverAspas(coluna[4]);
                    produto.Ncm = Produto.RemoverAspas(coluna[5]);
                    produto.Cest = Produto.RemoverAspas(coluna[6]);
                    produto.Embalagem = Produto.RemoverAspas(coluna[7]);
                    produto.Quantidade = decimal.TryParse(coluna[8], out var quantidade) == true ? quantidade : 0;
                    produto.FotoPng = Produto.RemoverAspas(coluna[9]);
                    produto.FotoGif = Produto.RemoverAspas(coluna[10]);
                    produto.Marca = Produto.RemoverAspas(coluna[11]);
                    produto.PrecoMedio = decimal.TryParse(coluna[12], out var precoMedio) == true ? precoMedio : 0;
                    produto.ImgGtin = Produto.RemoverAspas(coluna[13]);
                    produto.Categoria = Produto.RemoverAspas(coluna[14]);
                    produto.FotoTabloidePng = Produto.RemoverAspas(coluna[15]);
                    produto.FotoTabloideGif = Produto.RemoverAspas(coluna[16]);
                    try
                    {
                        context.Produtos.Add(produto);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Ocorreu um erro");
                        Console.WriteLine(linha);
                        Console.WriteLine(ex.Message);
                    }

                    if ((i % 1000) == 0)
                    {
                        Console.WriteLine($"Salvanod Produtos... {i} Salvos");
                        context.SaveChanges();
                    }
                }
            }

            context.SaveChanges();
            Console.WriteLine($"Produtos Salvos: {i}");

            stream.Close();
            context.SaveChanges();
            sw.Stop();
            var tempo = sw.Elapsed;
            Console.WriteLine($"PROCESSADO EM {tempo.TotalSeconds} SEGUNDOS");
        }
    }
}
