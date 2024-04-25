using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Infra.Context;

public class FortesAlimentacaoDbContext : DbContext
{
    private IConfiguration _configuration;

    public FortesAlimentacaoDbContext(IConfiguration configuration, DbContextOptions options)
        : base(options)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("FortesAlimentacaoConnection");
        optionsBuilder.UseNpgsql(connectionString);
    }
}
