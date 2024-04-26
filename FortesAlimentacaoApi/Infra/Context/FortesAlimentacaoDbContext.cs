using FortesAlimentacaoApi.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Infra.Context;

public class FortesAlimentacaoDbContext : DbContext
{
    private IConfiguration _configuration;
    public DbSet<Encarregado> Encarregados { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Operario> Operarios { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Obra> Obras { get; set; }
    public DbSet<GestaoEquipe> GestaoEquipes { get; set; }
    public DbSet<Equipe> Equipes { get; set; }
    public DbSet<ControleData> ControleDatas { get; set; }
    public DbSet<Refeicao> Refeicoes { get; set; }

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Operario>()
            .HasIndex(operario => operario.Matricula)
            .IsUnique();
    }
}
