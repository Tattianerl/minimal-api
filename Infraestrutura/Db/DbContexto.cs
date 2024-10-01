using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db
{
    public class DbContexto : DbContext
    {
        private readonly IConfiguration _configuracaoAppSettings;

        public DbContexto(IConfiguration configuracaoAppSettings)
        {
            _configuracaoAppSettings = configuracaoAppSettings;
        }

        // Definição de DbSet para as entidades
        public DbSet<Administrador> Administradores { get; set; } = default!;
        public DbSet<Veiculo> Veiculos { get; set; } = default!;

        // Configuração de dados iniciais (seeding)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador {
                    id = 1,
                    Email = "administrador@teste.com",
                    Senha = "123456", 
                    Perfil = "Adm"
                }
            );
        }

        // Configuração do DbContext para usar SQL Server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Obtém a string de conexão a partir do appsettings.json
                var stringConexao = _configuracaoAppSettings.GetConnectionString("sqlServer");

                if (!string.IsNullOrEmpty(stringConexao))
                {
                    // Configura o uso do SQL Server com a string de conexão
                    optionsBuilder.UseSqlServer(stringConexao);
                }
            }
        }
    }
}
