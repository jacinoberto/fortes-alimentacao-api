using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.ControleData;
using FortesAlimentacaoApi.Database.Dtos.Obra;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using FortesAlimentacaoApi.Util.DataObra;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Util.AbrirAgenda;

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
            var _todasObras = scope.ServiceProvider.GetRequiredService<TodasObras>();
            var _obrasSelecionadas = scope.ServiceProvider.GetRequiredService<ObraSelecionada>();

            _logger.LogInformation("A conferência de datas foi iniciada.");

            DateOnly dataDia = DateOnly.FromDateTime(DateTime.Today).AddDays(5);

            if (DateTime.Today.DayOfWeek is DayOfWeek.Tuesday)
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
                        ControleData controle = _mapper.Map<ControleData>(data);
                        await _context.AddAsync(controle);
                        await _context.SaveChangesAsync();

                        await _todasObras.Inserir(controle.Id);
                    }

                    ICollection<ObraSelect> obrasSelect = [];

                    if (controleData is not null
                        && controleData.Atipico is true)
                    {
                        InserirControleData data = new(dataDia, null, false);
                        ControleData controle = _mapper.Map<ControleData>(data);
                        await _context.AddAsync(controle);
                        await _context.SaveChangesAsync();

                        ICollection<Database.Models.DataObra> dataObras = _context.DataObras
                            .Where(data => data.ControleData.DataRefeicao == controle.DataRefeicao).ToList();

                        ICollection<Obra> obras = _context.Obras.ToList();
                        
                        foreach (var obra in obras)
                        {
                            foreach (var dataObra in dataObras)
                            {
                                if (dataObra.Obra.Id != obra.Id) obrasSelect.Add(new ObraSelect(obra.Id));
                            }
                        }

                        await _obrasSelecionadas.Inserir(obrasSelect, controle.Id);
                    }
                }

                _logger.LogInformation("As datas da próxima semana foram cadastradas.");
            }
            else _logger.LogWarning("O cadastro das datas não pode ser relizado hoje, apenas nas Quintas-Feiras.");

        }
    }
}
