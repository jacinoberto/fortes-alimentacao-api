using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Obra;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Services;

public class ObraService : IGlobalService<InserirObra, RetornarObra>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public ObraService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RetornarObra> Inserir(InserirObra entity)
    {
        Obra obra = _mapper.Map<Obra>(entity);
        await _context.Obras.AddAsync(obra);
        await _context.SaveChangesAsync();

        return _mapper.Map<RetornarObra>(obra);
    }

    public async Task<RetornarObra> RetornarPorId(Guid id)
    {
        return _mapper.Map<RetornarObra>(
            await _context.Obras.Include(obra => obra.Endereco)
            .FirstOrDefaultAsync(obra => obra.Id == id));
    }

    public async Task<IEnumerable<RetornarObra>> RetornarTodos()
    {
        return _mapper.Map<IEnumerable<RetornarObra>>(
            await _context.Obras.Include(obra => obra.Endereco).ToListAsync());
    }

    public async Task<bool> Deletar(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RetornarObraSelect>> RetornarSelect(string identificacao)
    {
        return _mapper.Map<IEnumerable<RetornarObraSelect>>(await _context.Obras
            .Where(obra => obra.Identificacao.ToUpper().Contains(identificacao.ToUpper()))
            .ToListAsync());
    }
}
