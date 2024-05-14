
namespace FortesAlimentacaoApi.Services.WorkSevice;

public class Work : IHostedService
{
    private Timer _timer;

    private ILogger<Work> _logger;
    private readonly AberturaAgendaService _agendaService;

    public Work(ILogger<Work> logger, AberturaAgendaService agendaService)
    {
        _logger = logger;
        _agendaService = agendaService;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("A abertura da agenda foi iniciada!");

        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

        return Task.CompletedTask;
    }

    public void DoWork(object? state)
    {
        Console.WriteLine($"{DateTime.UtcNow} => {_agendaService.PegarMensagem()}");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("A abertura da agenda foi finalizada!");

        return Task.CompletedTask;
    }
}
