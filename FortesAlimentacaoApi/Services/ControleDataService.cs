using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.ControleData;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Services;

public class ControleDataService : IGlobalService<InserirControleData, RetornarControleData>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public ControleDataService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RetornarControleData> Inserir(InserirControleData entity)
    {
        ControleData controleData = _mapper.Map<ControleData>(entity);
        await _context.ControleDatas.AddAsync(controleData);
        await _context.SaveChangesAsync();

        return _mapper.Map<RetornarControleData>(controleData);
    }

    public async Task<RetornarControleData> RetornarPorId(Guid id)
    {
        return _mapper.Map<RetornarControleData>(await _context.ControleDatas
            .FirstOrDefaultAsync(controle => controle.Id == id));
    }

    public async Task<IEnumerable<RetornarControleData>> RetornarTodos()
    {
        return _mapper.Map<IEnumerable<RetornarControleData>>(
            await _context.ControleDatas.ToListAsync());
    }

    public async Task<bool> Deletar(Guid id)
    {
        throw new NotImplementedException();
    }
}
