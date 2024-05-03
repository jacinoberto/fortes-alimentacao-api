using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using FortesAlimentacaoApi.Services;

namespace FortesAlimentacaoApi.Util;

public class Validacao
{
    private FortesAlimentacaoDbContext _context;
    private IMapper _mapper;

    public Validacao(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void ValidarData(Guid id, AtualizarRefeicao refeicaoDto)
    {
        Refeicao? refeicao = _context.Refeicoes
            .FirstOrDefault(refeicao => refeicao.Id == id);

        ControleData? controleData = _context.ControleDatas
            .FirstOrDefault(data => data.Id == refeicao.ControleDataId);

        DayOfWeek diaSemana = controleData.DataRefeicao.DayOfWeek;

        TimeSpan cafe = new TimeSpan(07,0,0);
        TimeSpan almoco = new TimeSpan(12,0,0);
        TimeSpan jantar = new TimeSpan(19,0,0);
        
        if (diaSemana is DayOfWeek.Saturday
            && diaSemana is DayOfWeek.Sunday
            && controleData.Atipico is false)
        {
        }
    }

    public void AbrirAgenda(IEnumerable<Equipe> equipes, IEnumerable<ControleData> datas)
    {
        var data = DateTime.Today.DayOfWeek;

        if (data is DayOfWeek.Thursday)
        {
            IEnumerable<ControleData> datasValidas = datas
                .Where(data => data.DataRefeicao > DateOnly.FromDateTime(DateTime.Today).AddDays(4)
                && data.DataRefeicao < data.DataRefeicao.AddDays(10))
                .ToList();

            foreach (ControleData controleData in datasValidas)
            {
                foreach (Equipe equipe in equipes)
                {

                    InserirRefeicao refeicaoDto = new InserirRefeicao(
                        equipe.Id,
                        true,
                        true,
                        true,
                        controleData.Id
                        );

                    _context.Refeicoes.Add(_mapper.Map<Refeicao>(refeicaoDto));
                    _context.SaveChanges();
                }                    
            }
        }
    }
}
