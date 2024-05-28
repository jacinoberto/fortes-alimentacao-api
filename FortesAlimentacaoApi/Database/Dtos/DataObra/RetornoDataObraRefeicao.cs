using FortesAlimentacaoApi.Database.Dtos.ControleData;
using FortesAlimentacaoApi.Database.Dtos.Obra;

namespace FortesAlimentacaoApi.Database.Dtos.DataObra;

public record RetornoDataObraRefeicao(
    RetornoObraGestao Obra,
    RetornoControleDataRefeicao ControleData
);
