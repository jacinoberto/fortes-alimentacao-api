using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Util.Filtro;

public class FiltrarDiaNaoAtipico : IFiltrarDia
{
    private readonly IMapper _mapper;
    private readonly IServiceProvider _serviceProvider;

    public FiltrarDiaNaoAtipico(IMapper mapper, IServiceProvider serviceProvider)
    {
        _mapper = mapper;
        _serviceProvider = serviceProvider;
    }

    public async Task<RefeicaoFiltro> Filtrar(AtualizarRefeicao refeicaoDto)
    {
        using(var scope = _serviceProvider.CreateScope())
        {
            var _context = scope.ServiceProvider.GetRequiredService<FortesAlimentacaoDbContext>();

            Refeicao? refeicao = _context.Refeicoes
                .Include(refeicao => refeicao.ControleData)
                .FirstOrDefault(refeicao => refeicao.Id == refeicaoDto.Id);

            if (refeicao is not null)
            {
                DayOfWeek diaSemana = refeicao.ControleData.DataRefeicao.DayOfWeek;

                if (diaSemana is not DayOfWeek.Saturday
                    || diaSemana is not DayOfWeek.Sunday
                    || refeicao.ControleData.Atipico is false)
                {
                    return new RefeicaoFiltro(refeicao, refeicaoDto);
                }
            }

            return null;
        }

    }
}
