using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.DataObra;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Util.DataObra;

public class TodasObras
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public TodasObras(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RetornoDataObra>> Inserir(Guid idControleData)
    {
        IEnumerable<Obra> obras = await _context.Obras.ToListAsync();
        ICollection<Database.Models.DataObra> dataObras = [];

        foreach (var obra in obras)
        {
            Database.Models.DataObra dataObra = _mapper.Map<Database.Models.DataObra>
                (new InserirDataObra(obra.Id, idControleData));

            dataObras.Add(dataObra);

            _context.DataObras.Add(dataObra);
            _context.SaveChanges();
        }

        return _mapper.Map<IEnumerable<RetornoDataObra>>(dataObras);
    }
}
