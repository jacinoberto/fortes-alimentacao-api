using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using FortesAlimentacaoApi.Util;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Services;

public class RefeicaoService : IGlobalService<InserirRefeicao, RetornarRefeicao>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;
    private readonly Validacao _validacao;

    public RefeicaoService(FortesAlimentacaoDbContext context, IMapper mapper, Validacao validacao)
    {
        _context = context;
        _mapper = mapper;
        _validacao = validacao;
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
            .FirstOrDefaultAsync(refeicao => refeicao.Id == id));
    }

    public async Task<IEnumerable<RetornarRefeicao>> RetornarTodos()
    {
        return _mapper.Map<IEnumerable<RetornarRefeicao>>(await _context.Refeicoes
            .Include(refeicao => refeicao.Equipe)
            .Include(refeicao => refeicao.Equipe.Operario)
            .ToListAsync());
    }

    public async Task<bool> Deletar(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Agenda()
    {
        IEnumerable<Equipe> equipes = _context.Equipes.Where(equipe => equipe.GestaoEquipe.Status == true).ToList();
        IEnumerable<ControleData> datas = _context.ControleDatas.ToList();

        _validacao.AbrirAgenda(equipes, datas);
    }
}
