using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.DataObra;
using FortesAlimentacaoApi.Infra.Context;
using FortesAlimentacaoApi.Util.DataObra;

namespace FortesAlimentacaoApi.Services;

public class DataObraService
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;
    private readonly ObraSelecionada _obraSelecionada;
    private readonly TodasObras _todasObras;
    private readonly ControleDataService _controleDataService;

    public DataObraService(FortesAlimentacaoDbContext context, IMapper mapper,
        ObraSelecionada obraSelecionada, TodasObras todasObras, ControleDataService controleDataService)
    {
        _context = context;
        _mapper = mapper;
        _obraSelecionada = obraSelecionada;
        _todasObras = todasObras;
        _controleDataService = controleDataService;
    }

    public async Task<IEnumerable<RetornoDataObra>> Inserir(CriarDataObra dataObraDto)
    {
        var controleData = await _controleDataService.Inserir(dataObraDto.ControleData);

        if (dataObraDto.Obras is not null) return await _obraSelecionada.Inserir(dataObraDto.Obras, controleData.Id);
        else return await _todasObras.Inserir(controleData.Id);
    }
}
