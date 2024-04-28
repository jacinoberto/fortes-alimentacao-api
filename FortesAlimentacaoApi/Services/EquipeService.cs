using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Equipe;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Services;

public class EquipeService : IGlobalService<InserirEquipe, RetornarEquipe, AtualizarEquipe>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public EquipeService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public RetornarEquipe Inserir(InserirEquipe entity)
    {
        Equipe equipe = _mapper.Map<Equipe>(entity);
        _context.Equipes.Add(equipe);
        _context.SaveChanges();

        return _mapper.Map<RetornarEquipe>(equipe);
    }

    public RetornarEquipe RetornarPorId(Guid id)
    {
        return _mapper.Map<RetornarEquipe>(_context.Equipes
            .Where<Equipe>(equipe => equipe.GestaoEquipe.Status == true)
            .Include(equipe => equipe.GestaoEquipe)
            .Include(equipe => equipe.GestaoEquipe.Obra)
            .Include(equipe => equipe.GestaoEquipe.Encarregado)
            .Include(equipe =>equipe.Operario)
            .FirstOrDefault(equipe => equipe.Id == id));
    }

    public IEnumerable<RetornarEquipe> RetornarTodos()
    {
        return _mapper.Map<IEnumerable<RetornarEquipe>>(_context.Equipes
            .Where<Equipe>(equipe => equipe.GestaoEquipe.Status == true)
            .Include(equipe => equipe.GestaoEquipe)
            .Include(equipe => equipe.GestaoEquipe.Obra)
            .Include(equipe => equipe.GestaoEquipe.Encarregado)
            .Include(equipe => equipe.Operario)
            .ToList());
    }
    public void Atualizar(Guid id, AtualizarEquipe entity)
    {
        throw new NotImplementedException();
    }

    public bool Deletar(Guid id)
    {
        throw new NotImplementedException();
    }
}
