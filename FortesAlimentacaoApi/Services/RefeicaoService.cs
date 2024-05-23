using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using FortesAlimentacaoApi.Util.WorkSevice;
using FortesAlimentacaoApi.Util;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using FortesAlimentacaoApi.Util.Validacao;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FortesAlimentacaoApi.Services;

public class RefeicaoService : IGlobalService<InserirRefeicao, RetornarRefeicao>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;
    private readonly RefeicaoPermitida _refeicao;
    private readonly AtualizarRefeicoes _atualizacao;

    public RefeicaoService(FortesAlimentacaoDbContext context, IMapper mapper,RefeicaoPermitida refeicao,
        AtualizarRefeicoes at)
    {
        _context = context;
        _mapper = mapper;
        _refeicao = refeicao;
        _atualizacao = at;
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
            .Where(refeicao => refeicao.Equipe.GestaoEquipe.EncarregadoId == id
            && refeicao.ControleData.DataRefeicao > DateOnly.FromDateTime(DateTime.Today)
            && refeicao.ControleData.DataRefeicao < refeicao.ControleData.DataRefeicao.AddDays(7))
            .Include(refeicao => refeicao.Equipe)
            .Include(refeicao => refeicao.Equipe.Operario)
            .Include(refeicao => refeicao.ControleData)
            .ToListAsync());
    }

    public async Task<bool> Deletar(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RetornarRefeicao>> AtualizarRefeicoes(Collection<AtualizarRefeicao> refeicoesDto)
    {
        Collection<Refeicao> refeicoes = [];

        foreach (AtualizarRefeicao refeicaoDto in refeicoesDto)
        {
            Refeicao refeicao = await _refeicao.RefeicoesPermitidasAtualizacoes(refeicaoDto);

            if (refeicao is not null)
            {
                refeicoes.Add(refeicao);
            }
        }

        return await _atualizacao.RefeicoesAtualizadas(refeicoes);
    }
}
