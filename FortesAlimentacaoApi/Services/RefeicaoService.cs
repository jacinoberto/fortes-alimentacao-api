using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using FortesAlimentacaoApi.Services.WorkSevice;
using FortesAlimentacaoApi.Util;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace FortesAlimentacaoApi.Services;

public class RefeicaoService : IGlobalService<InserirRefeicao, RetornarRefeicao>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;
    private readonly AbrirAgenda _validacao;
    private readonly ValidarAtualizacao _atualizacao;

    private readonly AberturaAgendaService _aberturaAgendaService;

    public RefeicaoService(FortesAlimentacaoDbContext context, IMapper mapper,
        AbrirAgenda validacao, ValidarAtualizacao atualizacao, AberturaAgendaService aberturaAgendaService)
    {
        _context = context;
        _mapper = mapper;
        _validacao = validacao;
        _atualizacao = atualizacao;
        _aberturaAgendaService = aberturaAgendaService;
    }

    public async Task<RetornarRefeicao> Inserir(InserirRefeicao entity)
    {
        Refeicao refeicao = _mapper.Map<Refeicao>(entity);
        await _context.Refeicoes.AddAsync(refeicao);
        await _context.SaveChangesAsync();

        return _mapper.Map<RetornarRefeicao>(refeicao);
    }

    public async Task<RetornarRefeicao> RetornarPorId(Guid id)
    {
        return _mapper.Map<RetornarRefeicao>(
            await _context.Refeicoes
            .Include(refeicao => refeicao.Equipe)
            .Include(refeicao => refeicao.Equipe.Operario)
            .Include(refeicao => refeicao.ControleData)
            .FirstOrDefaultAsync(refeicao => refeicao.Id == id));
    }

    public async Task<IEnumerable<RetornarRefeicao>> RetornarTodos()
    {
        return _mapper.Map<IEnumerable<RetornarRefeicao>>(await _context.Refeicoes
            .Include(refeicao => refeicao.Equipe)
            .Include(refeicao => refeicao.Equipe.Operario)
            .Include(refeicao => refeicao.ControleData)
            .ToListAsync());
    }

    public async Task<IEnumerable<RetornarRefeicao>> RetornarTodosPorIdEncarregado(Guid id)
    {
        return _mapper.Map<IEnumerable<RetornarRefeicao>>(await _context.Refeicoes
            .Where(refeicao => refeicao.Equipe.GestaoEquipe.EncarregadoId == id)
            .Include(refeicao => refeicao.Equipe)
            .Include(refeicao => refeicao.Equipe.Operario)
            .Include(refeicao => refeicao.ControleData)
            .ToListAsync());
    }

    public async Task<bool> Deletar(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task Agenda()
    {
        IEnumerable<Equipe> equipes = await _context.Equipes.Where(equipe => equipe.GestaoEquipe.Status == true).ToListAsync();
        IEnumerable<ControleData> datas = await _context.ControleDatas.ToListAsync();

        Task.Run(async () =>
        {
            await _aberturaAgendaService.Processar(equipes, datas);
        });
    }

    public async Task<IEnumerable<RetornarRefeicao>> AtualizarRefeicoes(Collection<AtualizarRefeicao> refeicoesDto)
    {
        Collection<Refeicao> refeicoes = [];

        foreach (AtualizarRefeicao refeicaoDto in refeicoesDto)
        {
            Refeicao refeicao = _atualizacao.RefeicoesPermitidasAtualizacoes(refeicaoDto);

            if (refeicao is not null)
            {
                refeicoes.Add(refeicao);
            }
        }

        return await _atualizacao.RefeicoesAtualizadas(refeicoes);
    }
}
