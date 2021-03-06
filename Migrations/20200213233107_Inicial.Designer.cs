﻿// <auto-generated />
using System;
using ImportadorCadastroEan.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ImportadorCadastroEan.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20200213233107_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ImportadorCadastroEan.Modelos.Produto", b =>
                {
                    b.Property<Guid>("GuidProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("Comissao")
                        .HasColumnType("int");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("DescricaoUpper")
                        .HasColumnName("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Embalagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<int>("EstoqueInicial")
                        .HasColumnType("int");

                    b.Property<string>("Gtin")
                        .HasColumnName("Ean")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<string>("Ncm")
                        .HasColumnName("NCM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrecoCusto")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoMedio")
                        .HasColumnName("PrecoVenda")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("QuantidadeEmbalagem")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Ucom")
                        .HasColumnName("UCom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuidProduto");

                    b.ToTable("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
