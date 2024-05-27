using FortesAlimentacaoApi.Database.Dtos.ControleData;
using FortesAlimentacaoApi.Database.Dtos.Obra;

namespace FortesAlimentacaoApi.Database.Dtos.DataObra;

public record CriarDataObra(
    IEnumerable<ObraSelect>? Obras,
    InserirControleData ControleData
);
