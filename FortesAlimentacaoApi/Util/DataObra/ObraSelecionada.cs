using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.DataObra;
using FortesAlimentacaoApi.Database.Dtos.Obra;
using FortesAlimentacaoApi.Infra.Context;

namespace FortesAlimentacaoApi.Util.DataObra;

public class ObraSelecionada
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public ObraSelecionada(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RetornoDataObra>> Inserir(IEnumerable<ObraSelect> obras, Guid idControleData)
    {
        ICollection<Database.Models.DataObra> dataObras = [];

        foreach (var obra in obras)
        {
            Database.Models.DataObra dataObra = _mapper.Map<Database.Models.DataObra>
                (new InserirDataObra(obra.Id, idControleData));

            dataObras.Add(dataObra);

            await _context.DataObras.AddAsync(dataObra);
            await _context.SaveChangesAsync();
        }

        return _mapper.Map<IEnumerable<RetornoDataObra>>(dataObras);
    }
}
