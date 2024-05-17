using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using FortesAlimentacaoApi.Util;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Services.WorkSevice;

public class AberturaAgendaService
{
    private string _mensagem = "Processo para abertura de agenda não está em execução!";

    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<AberturaAgendaService> _logger;

    public AberturaAgendaService(IServiceProvider serviceProvider, ILogger<AberturaAgendaService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public string PegarMensagem()
    {
        return _mensagem;
    }

    public void EnviarMensagem(string mensagem)
    {
        _mensagem = mensagem;
    }

    public async Task Persistir()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<FortesAlimentacaoDbContext>();

            // Exemplo de como usar o DbContext para manipular dados
            await dbContext.MonitorarAgendas.AddAsync(new MonitorarAgenda());
            await dbContext.SaveChangesAsync();
        }

        EnviarMensagem("Processo para abertura de agenda iniciado!");
    }

    public async Task Atualizar()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<FortesAlimentacaoDbContext>();

            // Exemplo de como usar o DbContext para manipular dados
            var back = await dbContext.MonitorarAgendas.FirstOrDefaultAsync(background => background.Status == "Processando" &&
            background.Checkado == false);

            if (back != null)
            {
                back.Status = "Sucesso";
                await dbContext.SaveChangesAsync();
            }
        }

        EnviarMensagem("Processo para abertura de agenda finalizado!");
    }

    public async Task Processar(IEnumerable<Equipe> equipes, IEnumerable<ControleData> datas)
    {
        _logger.LogInformation("Processo para abertura de agenda iniciado!");

        using (var scope = _serviceProvider.CreateScope())
        {
            await Persistir();

            var abrirAgenda = scope.ServiceProvider.GetRequiredService<AbrirAgend>();

            // Exemplo de como usar o DbContext para manipular dados
            await abrirAgenda.AberturaDeAgenda(equipes, datas);

            await Atualizar();
        }

        _logger.LogInformation("Processo para abertura de agenda finalizado!");
    }
}
