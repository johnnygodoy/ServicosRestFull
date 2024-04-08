using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ServicosRestFull.Models
{
    public class MeuBancoContextFactory : IDesignTimeDbContextFactory<MeuBanco>
    {
        public MeuBanco CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MeuBanco>();
            var connectionString = configuration.GetConnectionString("PostgresConnection");

            builder.UseNpgsql(connectionString);

            return new MeuBanco(builder.Options);
        }
    }
}
