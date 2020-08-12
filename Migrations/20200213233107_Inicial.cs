using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportadorCadastroEan.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    GuidProduto = table.Column<Guid>(nullable: false),
                    Ean = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    NCM = table.Column<string>(nullable: true),
                    UCom = table.Column<string>(nullable: true),
                    Embalagem = table.Column<string>(nullable: true),
                    QuantidadeEmbalagem = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PrecoVenda = table.Column<decimal>(nullable: false),
                    IdProduto = table.Column<int>(nullable: false),
                    PrecoCusto = table.Column<int>(nullable: false),
                    Comissao = table.Column<int>(nullable: false),
                    Estoque = table.Column<int>(nullable: false),
                    EstoqueInicial = table.Column<int>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    AtualizadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.GuidProduto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
