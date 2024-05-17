using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Util.AberturaAgenda;

public class AberturaAgenda
{
    private readonly IMapper _mapper;
    private readonly ILogger<AberturaAgenda> _logger;
    private readonly IServiceProvider _serviceProvider;

    public AberturaAgenda(IMapper mapper, ILogger<AberturaAgenda> logger, IServiceProvider serviceProvider)
    {
        _mapper = mapper;
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public async Task AbrirAgenda()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var _context = scope.ServiceProvider.GetRequiredService<FortesAlimentacaoDbContext>();

            _logger.LogInformation("A abertura da agenda foi inicada.");

            if (DateTime.Today.DayOfWeek is DayOfWeek.Thursday)
            {
                _logger.LogInformation("A abertura da agenda foi permitida.");

                IEnumerable<ControleData> datasValidas = await _context.ControleDatas
                .Where(data => data.DataRefeicao > DateOnly.FromDateTime(DateTime.Today).AddDays(3)
                && data.DataRefeicao < data.DataRefeicao.AddDays(7))
                .ToListAsync();

                IEnumerable<Equipe> equipes = await _context.Equipes.ToListAsync();

                foreach (ControleData controleData in datasValidas)
                {
                    foreach (Equipe equipe in equipes)
                    {

                        InserirRefeicao refeicaoDto = new InserirRefeicao(
                        equipe.Id,
                            controleData.Id
                        );

                        await _context.Refeicoes.AddAsync(_mapper.Map<Refeicao>(refeicaoDto));
                        await _context.SaveChangesAsync();
                    }
                }
            }
            else _logger.LogWarning("A agenda não pode ser aberta hoje, apenas nas Quintas-Feiras.");
        }
    }
}
