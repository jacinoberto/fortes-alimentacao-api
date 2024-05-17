using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Equipe;
using FortesAlimentacaoApi.Database.Dtos.Operario;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Services;

public class EquipeService : IGlobalService<InserirEquipe, RetornarEquipe>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;
    private readonly OperarioService _operarioService;

    public EquipeService(FortesAlimentacaoDbContext context, IMapper mapper, OperarioService operarioService)
    {
        _context = context;
        _mapper = mapper;
        _operarioService = operarioService;
    }


    public async Task<RetornarEquipe> Inserir(InserirEquipe entity)
    {
        Equipe equipe = _mapper.Map<Equipe>(entity);
        await _context.Equipes.AddAsync(equipe);
        await _context.SaveChangesAsync();

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

    public async Task Inserir(IEnumerable<InserirOperario> operariosDto,Guid idGestaoEquipe)
    {
        foreach (InserirOperario operarioDto in operariosDto)
        {
            var operario = await _operarioService.Inserir(operarioDto);
            await Inserir(new InserirEquipe(idGestaoEquipe, operario.Id));
        }
    }
}
