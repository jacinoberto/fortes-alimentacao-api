using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Services;

public class RefeicaoService : IGlobalService<InserirRefeicao, RetornarRefeicao, AtualizarRefeicao>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public RefeicaoService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public RetornarRefeicao Inserir(InserirRefeicao entity)
    {
        Refeicao refeicao = _mapper.Map<Refeicao>(entity);
        _context.Refeicoes.Add(refeicao);
        _context.SaveChanges();

        return _mapper.Map<RetornarRefeicao>(refeicao);
    }

    public RetornarRefeicao RetornarPorId(Guid id)
    {
        return _mapper.Map<RetornarRefeicao>(
            _context.Refeicoes
            .Include(refeicao => refeicao.Equipe)
            .Include(refeicao => refeicao.Equipe.Operario)
            .FirstOrDefault(refeicao => refeicao.Id == id));
    }

    public IEnumerable<RetornarRefeicao> RetornarTodos()
    {
        return _mapper.Map<IEnumerable<RetornarRefeicao>>(_context.Refeicoes
            .Include(refeicao => refeicao.Equipe)
            .Include(refeicao => refeicao.Equipe.Operario)
            .ToList());
    }

    public void Atualizar(Guid id, AtualizarRefeicao entity)
    {
        throw new NotImplementedException();
    }

    public bool Deletar(Guid id)
    {
        throw new NotImplementedException();
    }
}
