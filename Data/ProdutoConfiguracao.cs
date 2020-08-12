using ImportadorCadastroEan.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImportadorCadastroEan.Data
{
    internal class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(x => x.GuidProduto);
            builder.Property(x => x.QuantidadeEmbalagem).HasColumnType("decimal(10,2)");           
            builder.HasKey(x => x.GuidProduto);
            builder.Property(x => x.Gtin).HasColumnName("Ean");
            builder.Property(x => x.DescricaoUpper).HasColumnName("Descricao");
            builder.Property(x => x.Ncm).HasColumnName("NCM");
            builder.Property(x => x.Ucom).HasColumnName("UCom");
            builder.Property(x => x.PrecoMedio).HasColumnName("PrecoVenda");
            builder.Property(x => x.CriadoEm).HasDefaultValueSql("getdate()");
            builder.Property(x => x.AtualizadoEm).HasDefaultValueSql("getdate()");
        }
    }
}