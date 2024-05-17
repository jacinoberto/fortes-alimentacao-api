using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Util.AbrirAgenda;

public class FinalizarMonitoramento
{
    
    private readonly ILogger<FinalizarMonitoramento> _logger;
    private readonly IServiceProvider _serviceProvider;

    public FinalizarMonitoramento(IServiceProvider serviceProvider, ILogger<FinalizarMonitoramento> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task Finalizar()
    {
        _logger.LogInformation("Registro de monitoramento em processo de finalização.");

        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<FortesAlimentacaoDbContext>();

            var back = await dbContext.MonitorarAgendas.FirstOrDefaultAsync(background => background.Status == "Processando" &&
            background.Checkado == false);

            if (back != null)
            {
                back.Status = "Sucesso";
                await dbContext.SaveChangesAsync();

                _logger.LogInformation("Monitoramento finalizado com sucesso.");
            }
            else _logger.LogWarning("Não foi possível finalizar o monitoramento, nenhum dado foi encontrado.");

        }
    }
}
