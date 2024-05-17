using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.ControleData;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Util.AberturaAgenda;

public class ConferirControleData
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IMapper _mapper;
    private readonly ILogger<ConferirControleData> _logger;


    public ConferirControleData(IServiceProvider serviceProvider , IMapper mapper, ILogger<ConferirControleData> logger)
    {
        _serviceProvider = serviceProvider;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task ConferirControleDatas()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var _context = scope.ServiceProvider.GetRequiredService<FortesAlimentacaoDbContext>();

            _logger.LogInformation("A conferência de datas foi iniciada.");

            DateOnly dataDia = DateOnly.FromDateTime(DateTime.Today).AddDays(3);

            if (DateTime.Today.DayOfWeek is DayOfWeek.Thursday)
            {
                _logger.LogInformation("O cadastro das datas foi permitido.");

                for (int i = 1; i <= 7; i++)
                {
                    dataDia = dataDia.AddDays(1);

                    ControleData? controleData = await _context.ControleDatas
                        .FirstOrDefaultAsync(data => data.DataRefeicao == dataDia);

                    if (controleData is null)
                    {
                        InserirControleData data = new(dataDia, null, false);
                        await _context.AddAsync(_mapper.Map<ControleData>(data));
                        await _context.SaveChangesAsync();
                    }
                }

                _logger.LogInformation("As datas da próxima semana foram cadastradas.");
            }
            else _logger.LogWarning("O cadastro das datas não pode ser relizado hoje, apenas nas Quintas-Feiras.");

        }
    }
}
