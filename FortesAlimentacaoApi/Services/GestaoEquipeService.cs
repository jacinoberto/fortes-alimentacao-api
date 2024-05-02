using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.GestaoEquipe;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Services;

public class GestaoEquipeService : IGlobalService<InserirGestaoEquipe, RetornarGestaoEquipe>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public GestaoEquipeService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RetornarGestaoEquipe> Inserir(InserirGestaoEquipe entity)
    {
        GestaoEquipe gestaoEquipe = _mapper.Map<GestaoEquipe>(entity);
        await _context.GestaoEquipes.AddAsync(gestaoEquipe);
        await _context.SaveChangesAsync();

        return _mapper.Map<RetornarGestaoEquipe>(gestaoEquipe);
    }

    public async Task<RetornarGestaoEquipe> RetornarPorId(Guid id)
    {
        return _mapper.Map<RetornarGestaoEquipe>(
            await _context.GestaoEquipes.Where(gestao => gestao.Status == true)
            .Include(gestao => gestao.Obra)
            .Include(gestao => gestao.Encarregado)
            .FirstOrDefaultAsync(gestao => gestao.Id == id));
    }

    public async Task<IEnumerable<RetornarGestaoEquipe>> RetornarTodos()
    {
        return _mapper.Map<IEnumerable<RetornarGestaoEquipe>>(
            await _context.GestaoEquipes
            .Where(gestao => gestao.Status == true)
            .Include(gestao => gestao.Obra)
            .Include(gestao => gestao.Encarregado)
            .ToListAsync());
    }

    public async Task<bool> Deletar(Guid id)
    {
        GestaoEquipe? gestaoEquipe = await _context.GestaoEquipes.FirstOrDefaultAsync(
            gestao => gestao.Id == id);

        if (gestaoEquipe is not null)
        {
            gestaoEquipe.InativarGestaoEquipe();
            await _context.SaveChangesAsync();
            return true;
        }
        else return false;
    }
}
