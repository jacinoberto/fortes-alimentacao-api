using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using FortesAlimentacaoApi.Services;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

namespace FortesAlimentacaoApi.Util;

public class AbrirAgenda
{
    private FortesAlimentacaoDbContext _context;
    private IMapper _mapper;

    public AbrirAgenda(FortesAlimentacaoDbContext context, IMapper mapper)
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
            && controleData.Atipico is true)
        {
        }
    }

    public void ValidarDataAtualizacao(IEnumerable<AtualizarRefeicao> refeicoesAtualuzar)
    {
        IEnumerable<Refeicao> refeicoes = _mapper.Map<IEnumerable<Refeicao>>(refeicoesAtualuzar);

        TimeOnly cafe = new (7,0,0);
        TimeOnly almoco = new (12,0,0);
        TimeOnly jantar = new (19,0,0);

        foreach (Refeicao refeicao in refeicoes)
        {
            DayOfWeek diaSemana = refeicao.ControleData.DataRefeicao.DayOfWeek;

            if (diaSemana is DayOfWeek.Saturday
                && diaSemana is DayOfWeek.Sunday
                && refeicao.ControleData.Atipico is true)
            {
                DateTime horaAtual = DateTime.Now;

                DateTime cafeAtual = refeicao.ControleData.DataRefeicao.ToDateTime(new TimeOnly(horaAtual.Hour, horaAtual.Minute, horaAtual.Second));
                DateTime almocoAtual = refeicao.ControleData.DataRefeicao.ToDateTime(almoco);
                DateTime jantarAtual = refeicao.ControleData.DataRefeicao.ToDateTime(jantar);
            }
        }
    }

    public void AberturaDeAgenda(IEnumerable<Equipe> equipes, IEnumerable<ControleData> datas)
    {
        var data = DateTime.Today.DayOfWeek;

        if (data is DayOfWeek.Thursday)
        {
            IEnumerable<ControleData> datasValidas = datas
                .Where(data => data.DataRefeicao > DateOnly.FromDateTime(DateTime.Today).AddDays(3)
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
