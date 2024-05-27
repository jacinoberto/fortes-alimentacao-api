using FortesAlimentacaoApi.Database.Dtos.ControleData;
using FortesAlimentacaoApi.Database.Dtos.Obra;

namespace FortesAlimentacaoApi.Database.Dtos.DataObra;

public record RetornoDataObra(
    Guid Id,
    RetornoObraGestao Obra,
    RetornoControleDataRefeicao ControleData
);
