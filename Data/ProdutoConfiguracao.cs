using ImportadorCadastroEan.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImportadorCadastroEan.Data
{
    internal class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("BaseProdutosEan");
            builder.HasKey(x => x.GuidProduto);
            builder.Property(x => x.Gtin).HasColumnType("varchar(255)");
            builder.Property(x => x.DescricaoNormalizada).HasColumnType("varchar(255)");
            builder.Property(x => x.DescricaoUpper).HasColumnType("varchar(255)");
            builder.Property(x => x.DescricaoAcento).HasColumnType("varchar(255)");
            builder.Property(x => x.Peso).HasColumnType("varchar(60)");
            builder.Property(x => x.Ncm).HasColumnType("nvarchar(60)");
            builder.Property(x => x.Cest).HasColumnType("nvarchar(60)");
            builder.Property(x => x.Marca).HasColumnType("nvarchar(255)");
            builder.Property(x => x.Categoria).HasColumnType("nvarchar(255)");
            builder.Property(x => x.Embalagem).HasColumnType("nvarchar(255)");
            builder.Property(x => x.Quantidade).HasColumnType("decimal(10,2)");
            builder.Property(x => x.Cest).HasColumnType("nvarchar(60)");
            builder.Property(x => x.PrecoMedio).HasColumnType("decimal(10,2)");
            builder.Property(x => x.ImgGtin).HasColumnType("nvarchar(255)");
            builder.Property(x => x.FotoPng).HasColumnType("nvarchar(255)");
            builder.Property(x => x.FotoGif).HasColumnType("nvarchar(255)");
            builder.Property(x => x.FotoTabloideGif).HasColumnType("nvarchar(255)");
            builder.Property(x => x.FotoTabloidePng).HasColumnType("nvarchar(255)");
            builder.Property(x => x.CriadoEm).HasDefaultValueSql("getdate()");
            builder.Property(x => x.AtualizadoEm).HasDefaultValueSql("getdate()");
        }
    }
}