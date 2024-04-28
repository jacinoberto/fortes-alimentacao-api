using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.GestaoEquipe;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Services;

public class GestaoEquipeService : IGlobalService<InserirGestaoEquipe, RetornarGestaoEquipe, AtualizarGestaoEquipe>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public GestaoEquipeService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public RetornarGestaoEquipe Inserir(InserirGestaoEquipe entity)
    {
        GestaoEquipe gestaoEquipe = _mapper.Map<GestaoEquipe>(entity);
        _context.GestaoEquipes.Add(gestaoEquipe);
        _context.SaveChanges();

        return _mapper.Map<RetornarGestaoEquipe>(gestaoEquipe);
    }

    public RetornarGestaoEquipe RetornarPorId(Guid id)
    {
        return _mapper.Map<RetornarGestaoEquipe>(
            _context.GestaoEquipes.Where<GestaoEquipe>(gestao => gestao.Status == true)
            .Include(gestao => gestao.Obra)
            .Include(gestao => gestao.Encarregado)
            .FirstOrDefault(gestao => gestao.Id == id));
    }

    public IEnumerable<RetornarGestaoEquipe> RetornarTodos()
    {
        return _mapper.Map<IEnumerable<RetornarGestaoEquipe>>(
            _context.GestaoEquipes
            .Where<GestaoEquipe>(gestao => gestao.Status == true)
            .Include(gestao => gestao.Obra)
            .Include(gestao => gestao.Encarregado)
            .ToList());
    }
    public void Atualizar(Guid id, AtualizarGestaoEquipe entity)
    {
        throw new NotImplementedException();
    }

    public bool Deletar(Guid id)
    {
        GestaoEquipe? gestaoEquipe = _context.GestaoEquipes.FirstOrDefault(
            gestao => gestao.Id == id);

        if (gestaoEquipe is not null)
        {
            gestaoEquipe.InativarGestaoEquipe();
            _context.SaveChanges();
            return true;
        }
        else return false;
    }
}
