using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Encarregado;
using FortesAlimentacaoApi.Database.Dtos.GestaoEquipe;
using FortesAlimentacaoApi.Database.Dtos.Obra;
using FortesAlimentacaoApi.Database.Dtos.Operario;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Services;

public class SelectService
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public SelectService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EncarregadoSelect>> SelectEncarregadoAsync()
    {
        return _mapper.Map<IEnumerable<EncarregadoSelect>>(await _context.Encarregados
            .Where(encarregado => encarregado.Gestor.Status == true)
            .ToListAsync());
    }

    public async Task<IEnumerable<GestaoEquipeSelect>> SelectGestaoEquipeAsync()
    {
        return _mapper.Map<IEnumerable<GestaoEquipeSelect>>(await _context.GestaoEquipes
            .Where(gestao => gestao.Status == true)
            .Include(gestao => gestao.Obra)
            .Include(gestao => gestao.Encarregado)
            .ToListAsync());
    }

    public async Task<IEnumerable<OperarioSelect>> SelectOperarioAsync(string nome)
    {
        return _mapper.Map<IEnumerable<OperarioSelect>>(await _context.Operarios
            .Where(operario => operario.Nome.ToUpper().Contains(nome.ToUpper()))
            .Where(operario => operario.Status == true)
            .ToListAsync());
    }

    public async Task<IEnumerable<ObraSelectData>> SelectObraAsync()
    {
        return _mapper.Map<IEnumerable<ObraSelectData>>(await _context.Obras
            .Include(obra => obra.Endereco).ToListAsync());
    }
}
