using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Encarregado;
using FortesAlimentacaoApi.Database.Dtos.Relatorio;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using FortesAlimentacaoApi.Util.ValidarDatas;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FortesAlimentacaoApi.Services;

public class RelatorioService
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;
    private readonly IEnumerable<IDiaSemanaStrategy> _diasSemana;

    public RelatorioService(FortesAlimentacaoDbContext conteext, IMapper mapper, IEnumerable<IDiaSemanaStrategy> diasSemana)
    {
        _context = conteext;
        _mapper = mapper;
        _diasSemana = diasSemana;
    }

    public async Task<int> TotalCafe(Guid idEncarregado, DateOnly data)
    {
        return await _context.Refeicoes
                    .Where(refeicao => refeicao.Equipe.GestaoEquipe.EncarregadoId == idEncarregado
                        && refeicao.DataObra.ControleData.DataRefeicao == data
                        && refeicao.Cafe == true).CountAsync();
    }

    public async Task<int> TotalAlmoco(Guid idEncarregado, DateOnly data)
    {
        return await _context.Refeicoes
                    .Where(refeicao => refeicao.Equipe.GestaoEquipe.EncarregadoId == idEncarregado
                        && refeicao.DataObra.ControleData.DataRefeicao == data
                        && refeicao.Almoco == true).CountAsync();
    }

    public async Task<int> TotalJantar(Guid idEncarregado, DateOnly data)
    {
        return await _context.Refeicoes
                    .Where(refeicao => refeicao.Equipe.GestaoEquipe.EncarregadoId == idEncarregado
                        && refeicao.DataObra.ControleData.DataRefeicao == data
                        && refeicao.Jantar == true).CountAsync();
    }

    public async Task<IEnumerable<Encarregado>> EncarregadosAtivos()
    {
        return await _context.Encarregados.Where(encarregado => encarregado.Gestor.Status == true).ToListAsync();
    }

    public HashSet<DateOnly> RetornarDatas()
    {
        DateOnly dataHoje = DateOnly.FromDateTime(DateTime.Today);
        DiaSemana diaHoje = null;

        foreach (var dia in _diasSemana)
        {
            if (dia.Verificar(dataHoje) is not null)
            {
                diaHoje = dia.Verificar(dataHoje);
            }
        }

        return _context.Refeicoes
                .Where(refeicao => refeicao.DataObra.ControleData.DataRefeicao >= diaHoje.DataInicial
                && refeicao.DataObra.ControleData.DataRefeicao <= diaHoje.DataFinal)
                .Include(refeicao => refeicao.DataObra)
                .Include(refeicao => refeicao.DataObra.ControleData)
                .Select(refeicao => refeicao.DataObra.ControleData.DataRefeicao)
                .OrderBy(data => data)
                .ToHashSet();
    }

    public HashSet<DateOnly> RetornarDatas(DateOnly dataInicial, DateOnly dataFinal)
    {
        return _context.Refeicoes
                .Where(refeicao => refeicao.DataObra.ControleData.DataRefeicao >= dataInicial
                && refeicao.DataObra.ControleData.DataRefeicao <= dataFinal)
                .Include(refeicao => refeicao.DataObra)
                .Include(refeicao => refeicao.DataObra.ControleData)
                .Select(refeicao => refeicao.DataObra.ControleData.DataRefeicao)
                .OrderBy(data => data)
                .ToHashSet();
    }

    public string? RetornarSetor(Guid idEncarregado)
    {
        var gestaoEquipe = _context.GestaoEquipes
            .FirstOrDefault(gestao => gestao.EncarregadoId == idEncarregado);

        return gestaoEquipe.Setor;
    }

    public async Task<IEnumerable<RetornoRelatorio>> Relatorio()
    {
        ICollection<RetornoRelatorio> retornoRelatorios = [];

        HashSet<DateOnly> datas = RetornarDatas();

        var encarregados = await EncarregadosAtivos();

        string setor = "";

        int total = 0;

        foreach (var encarregado in encarregados)
        {
            ICollection<Relatorio> relatorios = [];

            setor = RetornarSetor(encarregado.Id);

            foreach (var data in datas)
            {
                int totalCafe = TotalCafe(encarregado.Id, data).Result;
                int totalAlmoco = TotalAlmoco(encarregado.Id, data).Result;
                int totalJantar = TotalJantar(encarregado.Id, data).Result;

                if (relatorios.Count() == 0)
                {
                    relatorios.Add(new Relatorio(
                        data,
                        totalCafe,
                        totalAlmoco,
                        totalJantar
                        ));

                    total = total + totalCafe + totalAlmoco + totalJantar;
                }

                var relatorio = relatorios.Where(relatorio => relatorio.DataRefeicao == data);

                if (relatorio.Count() == 0)
                {
                    relatorios.Add(new Relatorio(
                        data,
                        totalCafe,
                        totalAlmoco,
                        totalJantar
                        ));

                    total = total + totalCafe + totalAlmoco + totalJantar;
                }
            }

            retornoRelatorios.Add(new RetornoRelatorio(
                encarregado.Gestor.Nome,
                relatorios,
                setor,
                total
                ));
        }

        return retornoRelatorios;
    }

    public async Task<IEnumerable<RetornoRelatorio>> Relatorio(DateOnly dataInicial, DateOnly dataFinal)
    {
        ICollection<RetornoRelatorio> retornoRelatorios = [];

        HashSet<DateOnly> datas = RetornarDatas(dataInicial, dataFinal);

        var encarregados = await EncarregadosAtivos();

        string setor;
        int total = 0;

        foreach (var encarregado in encarregados)
        {
            ICollection<Relatorio> relatorios = [];
            setor = RetornarSetor(encarregado.Id);

            foreach (var data in datas)
            {
                int totalCafe = TotalCafe(encarregado.Id, data).Result;
                int totalAlmoco = TotalAlmoco(encarregado.Id, data).Result;
                int totalJantar = TotalJantar(encarregado.Id, data).Result;

                if (relatorios.Count() == 0)
                {
                    relatorios.Add(new Relatorio(
                        data,
                        totalCafe,
                        totalAlmoco,
                        totalJantar
                        ));

                    total = totalCafe + totalAlmoco + totalJantar;
                }

                var relatorio = relatorios.Where(relatorio => relatorio.DataRefeicao == data);

                if (relatorio.Count() == 0)
                {
                    relatorios.Add(new Relatorio(
                        data,
                        totalCafe,
                        totalAlmoco,
                        totalJantar
                        ));

                    total = totalCafe + totalAlmoco + totalJantar;
                }
            }

            retornoRelatorios.Add(new RetornoRelatorio(
                encarregado.Gestor.Nome,
                relatorios,
                setor,
                total
                ));
        }

        return retornoRelatorios;
    }
}
