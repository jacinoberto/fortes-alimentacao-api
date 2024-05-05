using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace FortesAlimentacaoApi.Util;

public class ValidarAtualizacao
{
    private FortesAlimentacaoDbContext _context;
    private IMapper _mapper;

    public ValidarAtualizacao(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public RefeicaoFiltro? FiltrarDiasAtipicos(AtualizarRefeicao refeicaoDto)
    {
        Refeicao? refeicao = _mapper.Map<Refeicao>(_context.Refeicoes
            .Include(refeicao => refeicao.ControleData)
            .FirstOrDefault(refeicao => refeicao.Id == refeicaoDto.Id));
        
        if(refeicao != null)
        {
            DayOfWeek diaSemana = refeicao.ControleData.DataRefeicao.DayOfWeek;

            if (diaSemana is DayOfWeek.Saturday
                || diaSemana is DayOfWeek.Sunday
                || refeicao.ControleData.Atipico is true)
            {
                return new RefeicaoFiltro(refeicao, refeicaoDto);
            }
        }
        Console.WriteLine("Atipico");

        return null;
    }

    public RefeicaoFiltro? FiltrarDiasNaoAtipicos(AtualizarRefeicao refeicaoDto)
    {
        Refeicao? refeicao = _context.Refeicoes.FirstOrDefault(refeicao => refeicao.Id == refeicaoDto.Id);

        DayOfWeek diaSemana = refeicao.ControleData.DataRefeicao.DayOfWeek;

        if (diaSemana is not DayOfWeek.Saturday
            || diaSemana is not DayOfWeek.Sunday
            || refeicao.ControleData.Atipico is false)
        {
            return new RefeicaoFiltro(refeicao, refeicaoDto);
        }

        Console.WriteLine("Não atipico");

        return null;
    }

    public Refeicao? ValidarDatasAtipicas(AtualizarRefeicao refeicaoAtualizar)
    {
        TimeOnly cafe = new(7, 0, 0);
        TimeOnly almoco = new(12, 0, 0);
        TimeOnly jantar = new(19, 0, 0);

        RefeicaoFiltro? filtro = FiltrarDiasAtipicos(refeicaoAtualizar);

        if (filtro is not null)
        {
            Refeicao refeicao = filtro.Refeicao;
            AtualizarRefeicao refeicaoDto = filtro.AtualizarRefeicao;

            DateTime dataHoraAtual = DateTime.Now;
            DateTime dataHoraRefeicao = new DateTime();
            TimeSpan diferenca = new TimeSpan(0, 12, 0, 0);
            TimeSpan tempo = new TimeSpan();

            if (refeicao.Cafe != refeicaoDto.Cafe) 
            {
                dataHoraRefeicao = refeicao.ControleData.DataRefeicao.ToDateTime(cafe);
                tempo = dataHoraRefeicao - dataHoraAtual;

                if (tempo >= diferenca)
                {
                    refeicao.Cafe = refeicaoDto.Cafe;
                }
            }

            if (refeicao.Almoco != refeicaoDto.Almoco) 
            {
                dataHoraRefeicao = refeicao.ControleData.DataRefeicao.ToDateTime(almoco);
                tempo = dataHoraRefeicao - dataHoraAtual;

                if (tempo >= diferenca)
                {
                    refeicao.Almoco = refeicaoDto.Almoco;
                }
            }

            if (refeicao.Jantar != refeicaoDto.Jantar)
            {
                dataHoraRefeicao = refeicao.ControleData.DataRefeicao.ToDateTime(jantar);
                tempo = dataHoraRefeicao - dataHoraAtual;
                if (tempo >= diferenca)
                {
                    refeicao.Jantar = refeicaoDto.Jantar;
                }
            }

            return refeicao;
        }

        return null;
    }

    public Refeicao? ValidarDatasNaoAtipicas(AtualizarRefeicao refeicaoAtualizar)
    {
        TimeOnly cafe = new(7, 0, 0);
        TimeOnly almoco = new(12, 0, 0);
        TimeOnly jantar = new(19, 0, 0);

        RefeicaoFiltro? filtro = FiltrarDiasNaoAtipicos(refeicaoAtualizar);

        if (filtro is not null)
        {
            Refeicao refeicao = filtro.Refeicao;
            AtualizarRefeicao refeicaoDto = filtro.AtualizarRefeicao;

            DateTime dataHoraAtual = DateTime.Now;
            DateTime dataHoraRefeicao = new DateTime();
            TimeSpan diferenca = new TimeSpan(2, 0, 0, 0);
            TimeSpan tempo = new TimeSpan();

            if (refeicao.Cafe != refeicaoDto.Cafe)
            {
                dataHoraRefeicao = refeicao.ControleData.DataRefeicao.ToDateTime(cafe);
                tempo = dataHoraRefeicao - dataHoraAtual;

                Console.WriteLine(tempo);
                if (tempo >= diferenca)
                {
                    refeicao.Cafe = refeicaoDto.Cafe;
                }
            }

            if (refeicao.Almoco != refeicaoDto.Almoco)
            {
                dataHoraRefeicao = refeicao.ControleData.DataRefeicao.ToDateTime(almoco);
                tempo = dataHoraRefeicao - dataHoraAtual;

                Console.WriteLine(tempo);
                if (tempo >= diferenca)
                {
                    refeicao.Almoco = refeicaoDto.Almoco;
                }
            }

            if (refeicao.Jantar != refeicaoDto.Jantar)
            {
                dataHoraRefeicao = refeicao.ControleData.DataRefeicao.ToDateTime(jantar);
                tempo = dataHoraRefeicao - dataHoraAtual;
                if (tempo >= diferenca)
                {
                    refeicao.Jantar = refeicaoDto.Jantar;
                }
            }

            return refeicao;
        }

        return null;
    }

    public Collection<Refeicao> RefeicoesPermitidasAtualizacoes(AtualizarRefeicao refeicaoDto)
    {
        Collection<Refeicao> refeicoes = [];

        if (ValidarDatasAtipicas(refeicaoDto) is not null) refeicoes.Add(ValidarDatasAtipicas(refeicaoDto));
        
        if (ValidarDatasNaoAtipicas(refeicaoDto) is not null) refeicoes.Add(ValidarDatasNaoAtipicas(refeicaoDto));

        return refeicoes;
    }
}
