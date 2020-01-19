using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportadorCadastroEan.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseProdutosEan",
                columns: table => new
                {
                    GuidProduto = table.Column<Guid>(nullable: false),
                    Gtin = table.Column<string>(type: "varchar(255)", nullable: true),
                    DescricaoNormalizada = table.Column<string>(type: "varchar(255)", nullable: true),
                    DescricaoUpper = table.Column<string>(type: "varchar(255)", nullable: true),
                    DescricaoAcento = table.Column<string>(type: "varchar(255)", nullable: true),
                    Peso = table.Column<string>(type: "varchar(60)", nullable: true),
                    Ncm = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    Cest = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Embalagem = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Quantidade = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PrecoMedio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImgGtin = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    FotoPng = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    FotoGif = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    FotoTabloidePng = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    FotoTabloideGif = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    AtualizadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseProdutosEan", x => x.GuidProduto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseProdutosEan");
        }
    }
}
