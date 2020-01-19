using ImportadorCadastroEan.Modelos;
using Microsoft.EntityFrameworkCore;
using System;

namespace ImportadorCadastroEan.Data
{
    internal class EFContext : DbContext
    {
        // Informar a ConnectionString
        private readonly string _connectionString = ConfiguracaoPersitencia.EFConnectionString;

        public EFContext()
        {
            if (string.IsNullOrEmpty(_connectionString))
                throw new ArgumentNullException("ConnectionString não informada");

            //Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoConfiguracao());
        }

        public DbSet<Produto> Produtos { get; protected set; }
    }
}
