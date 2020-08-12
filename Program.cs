using ImportadorCadastroEan.Data;
using ImportadorCadastroEan.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.IO;

namespace ImportadorCadastroEan
{
    class Program
    {
        public static EFContext contexto;

        static void Main(string[] args)
        {
            contexto = new EFContext();

            //contexto.Database.EnsureCreated();
            //contexto.Database.Migrate();

            // localCsv = informar a path do arquivo csv
            var localCsv = ConfiguracaoPersitencia.LocalArquivoCsv;

            var before0 = GC.CollectionCount(0);
            var before1 = GC.CollectionCount(1);
            var before2 = GC.CollectionCount(2);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var regBom = ExecutarNovo(localCsv);

            sw.Stop();
            var tempo = sw.Elapsed;
            Console.WriteLine($"REGISTROS BOM {regBom}");
            Console.WriteLine($"PROCESSADO EM {tempo.TotalSeconds} SEGUNDOS");
            Console.WriteLine($"# GEN0: {GC.CollectionCount(0) - before0}");
            Console.WriteLine($"# GEN1: {GC.CollectionCount(1) - before1}");
            Console.WriteLine($"# GEN2: {GC.CollectionCount(2) - before2}");
            Console.WriteLine($"#MEMORY: {Process.GetCurrentProcess().WorkingSet64/1024/1024} mb");
            
        }

        static int ExecutarNovo(string localCsv)
        {
            string linha;
            int count = 0;
            int regBom = 0;

            using (var fs = File.OpenRead(localCsv))
            using (var stream = new StreamReader(fs))
                while ((linha = stream.ReadLine()) != null)
                {
                    var colunas = linha.Split(',');
                    if (colunas.Length == 17)
                    {
                        var produto = TratarLinhaCom17Colunas(colunas, count, contexto);
                        if(produto != null)
                            regBom++;
                    }
                    count++;
                }
            return regBom;
        }

        private static Produto TratarLinhaCom17Colunas(string[] colunas, int linha, EFContext context)
        {
            var produto = new Produto();
            produto.Gtin = Produto.RemoverAspas(colunas[0]);
            produto.DescricaoUpper = Produto.RemoverAspas(colunas[2]);
            //produto.Peso = Produto.RemoverAspas(coluna[4]);
            produto.Ncm = Produto.RemoverAspas(colunas[5]);
            //produto.Cest = Produto.RemoverAspas(coluna[6]);
            produto.Embalagem = Produto.RemoverAspas(colunas[7]);
            produto.QuantidadeEmbalagem = decimal.TryParse(Produto.RemoverAspas(colunas[8]), out var quantidade) == true ? quantidade : 0;
            //produto.FotoPng = Produto.RemoverAspas(coluna[9]);
            //produto.FotoGif = Produto.RemoverAspas(coluna[10]);
            //produto.Marca = Produto.RemoverAspas(coluna[11]);
            produto.PrecoMedio = decimal.TryParse(Produto.RemoverAspas(colunas[12]), out var precoMedio) == true ? precoMedio : 0;
            //produto.ImgGtin = Produto.RemoverAspas(coluna[13]);
            //produto.Categoria = Produto.RemoverAspas(coluna[14]);
            //produto.FotoTabloidePng = Produto.RemoverAspas(coluna[15]);
            //produto.FotoTabloideGif = Produto.RemoverAspas(coluna[16]);
            try
            {
                //Console.WriteLine(linha);
                if (produto.PrecoMedio > 0 && linha > 0)
                {
                    //Console.WriteLine($"{linha} - {produto.DescricaoUpper}");
                    var sql = "INSERT INTO [Produtos] ([GuidProduto], [AtualizadoEm], [Comissao], [CriadoEm], [Descricao], [Estoque], [EstoqueInicial], [Ean], [NCM], [PrecoCusto], [PrecoVenda], [UCom], [Caixa], [ContaEstoque], [Status], [Composto],[ExibirNaTabela]) " +
                    "VALUES(newid(), getdate(), 0, getdate(), @descricao, 0, 0, @ean, @ncm, 0, @precovenda, @ucom, @QuantidadeEmbalagem, 1, 1, 0, 1)";
                    context.Database.ExecuteSqlRaw(sql,
                        new SqlParameter[] {
                            new SqlParameter("@descricao", produto.DescricaoUpper),
                            new SqlParameter("@ncm", produto.Ncm),
                            new SqlParameter("@ean", produto.Gtin),
                            new SqlParameter("@idproduto", linha),
                            new SqlParameter("@precovenda", produto.PrecoMedio / 100),
                            new SqlParameter("@ucom", Zion.Common.Helpers.PersistHelper.DBNullHandler(produto.Embalagem)),
                            new SqlParameter("@QuantidadeEmbalagem", produto.QuantidadeEmbalagem)
                        }
                    );
                    return produto;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ocorreu um erro");
                Console.WriteLine(produto.DescricaoUpper);
            }
            return null;
        }
    }
}
