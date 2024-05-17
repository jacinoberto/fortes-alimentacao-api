using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;

namespace FortesAlimentacaoApi.Util.AbrirAgenda;

public class RegistrarMonitoramento
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<RegistrarMonitoramento> _logger;

    public RegistrarMonitoramento(IServiceProvider serviceProvider, ILogger<RegistrarMonitoramento> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task Registrar()
    {
        _logger.LogInformation("Registro iniciado.");

        using (var scope = _serviceProvider.CreateScope())
        {

            var dbContext = scope.ServiceProvider.GetRequiredService<FortesAlimentacaoDbContext>();

            // Exemplo de como usar o DbContext para manipular dados
            await dbContext.MonitorarAgendas.AddAsync(new MonitorarAgenda());
            await dbContext.SaveChangesAsync();
            
            _logger.LogInformation($"Registro realizado com sucesso em {DateTime.Now}");
        }
    }
}
