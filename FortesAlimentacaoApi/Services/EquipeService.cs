using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Equipe;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Services;

public class EquipeService : IGlobalService<InserirEquipe, RetornarEquipe>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public EquipeService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<RetornarEquipe> Inserir(InserirEquipe entity)
    {
        Equipe equipe = _mapper.Map<Equipe>(entity);
        await _context.SaveChangesAsync();
        await _context.Equipes.AddAsync(equipe);

        return _mapper.Map<RetornarEquipe>(equipe);
    }

    public async Task<RetornarEquipe> RetornarPorId(Guid id)
    {
        return _mapper.Map<RetornarEquipe>(await _context.Equipes
            .Where(equipe => equipe.GestaoEquipe.Status == true)
            .Include(equipe => equipe.GestaoEquipe)
            .Include(equipe => equipe.GestaoEquipe.Obra)
            .Include(equipe => equipe.GestaoEquipe.Encarregado)
            .Include(equipe => equipe.Operario)
            .FirstOrDefaultAsync(equipe => equipe.Id == id));
    }

    public async Task<IEnumerable<RetornarEquipe>> RetornarTodos()
    {
        return _mapper.Map<IEnumerable<RetornarEquipe>>(await _context.Equipes
            .Where(equipe => equipe.GestaoEquipe.Status == true)
            .Include(equipe => equipe.GestaoEquipe)
            .Include(equipe => equipe.GestaoEquipe.Obra)
            .Include(equipe => equipe.GestaoEquipe.Encarregado)
            .Include(equipe => equipe.Operario)
            .ToListAsync());
    }

    public async Task<bool> Deletar(Guid id)
    {
        throw new NotImplementedException();
    }
}
