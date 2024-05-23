using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Encarregado;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FortesAlimentacaoApi.Services;

public class EncarregadoService : IGlobalService<InserirEncarregado, RetornarEncarregado>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public EncarregadoService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RetornarEncarregado> Inserir(InserirEncarregado entity)
    {
        Encarregado encaregado = _mapper.Map<Encarregado>(entity);
        await _context.Encarregados.AddAsync(encaregado);
        await _context.SaveChangesAsync();

        return _mapper.Map<RetornarEncarregado>(encaregado);
    }

    public async Task<RetornarEncarregado> RetornarPorId(Guid id)
    {
        return _mapper.Map<RetornarEncarregado>(await _context.Encarregados
            .Where(encarregado => encarregado.Gestor.Status == true)
            .FirstOrDefaultAsync(encarregado => encarregado.Id == id));
    }

    public async Task<IEnumerable<RetornarEncarregado>> RetornarTodos()
    {
        return _mapper.Map<IEnumerable<RetornarEncarregado>>(await _context.Encarregados
            .Where(encarregado => encarregado.Gestor.Status == true)
            .ToListAsync());
    }

    public async Task<bool> Deletar(Guid id)
    {
        Encarregado? encarregado = await _context.Encarregados
            .FirstOrDefaultAsync(encarregado => encarregado.Id == id);

        if (encarregado is not null)
        {
            encarregado.InativarPerfil();
            await _context.SaveChangesAsync();
            return true;
        }
        else return false;
    }

    public async Task<RetornoEncarregadoLogin>? Login(EncarregadoLogin login)
    {
        Encarregado encarregado = await _context.Encarregados
            .FirstAsync(encarregado => login.Email == encarregado.Gestor.Email
            && login.Senha == encarregado.Gestor.Senha);

        return encarregado is not null ? _mapper.Map<RetornoEncarregadoLogin>(encarregado) : null;
    }    
}
