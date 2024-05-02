namespace FortesAlimentacaoApi.Services;

using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Operario;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

public class OperarioService : IGlobalService<InserirOperario, RetornarOperario>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public OperarioService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RetornarOperario> Inserir(InserirOperario entity)
    {
        Operario operario = _mapper.Map<Operario>(entity);
        await _context.AddAsync(operario);
        await _context.SaveChangesAsync();

        return _mapper.Map<RetornarOperario>(operario);
    }

    public async Task<IEnumerable<RetornarOperario>> RetornarTodos()
    {
        return _mapper.Map<IEnumerable<RetornarOperario>>(
            await _context.Operarios.Where(
                operario => operario.Status == true)
            .ToListAsync());
    }

    public async Task<RetornarOperario> RetornarPorId(Guid id)
    {
        return _mapper.Map<RetornarOperario>(await _context.Operarios
            .Where(operario => operario.Status == true)
            .FirstOrDefaultAsync(operario => operario.Id == id));
    }

    public async Task<bool> Deletar(Guid id)
    {
        Operario? operario = _context.Operarios
            .FirstOrDefault(operario => operario.Id == id);

        if (operario is not null)
        {
            operario.InativarPerfil();
            await _context.SaveChangesAsync();
            return true;
        }
        else return false;
    }
}
