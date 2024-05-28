using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Util.AbrirAgenda;

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

            if (DateTime.Today.DayOfWeek is DayOfWeek.Monday)
            {
                _logger.LogInformation("A abertura da agenda foi permitida.");

                IEnumerable<Database.Models.DataObra> datasValidas = await _context.DataObras
                .Where(data => data.ControleData.DataRefeicao > DateOnly.FromDateTime(DateTime.Today).AddDays(6)
                && data.ControleData.DataRefeicao < data.ControleData.DataRefeicao.AddDays(7))
                .Include(data => data.Obra)
                .ToListAsync();

                IEnumerable<Equipe> equipes = await _context.Equipes.Include(equipe => equipe.GestaoEquipe.Obra).ToListAsync();

                foreach (Database.Models.DataObra dataObra in datasValidas)
                {
                    foreach (Equipe equipe in equipes)
                    {
                        if (dataObra.Obra == equipe.GestaoEquipe.Obra)
                        {
                            InserirRefeicao refeicaoDto = new InserirRefeicao(
                                equipe.Id,
                                dataObra.Id
                            );

                            await _context.Refeicoes.AddAsync(_mapper.Map<Refeicao>(refeicaoDto));
                            await _context.SaveChangesAsync();
                        }

                    }
                }
            }
            else _logger.LogWarning("A agenda não pode ser aberta hoje, apenas nas Quintas-Feiras.");
        }
    }
}
