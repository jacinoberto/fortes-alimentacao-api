using FortesAlimentacaoApi.Database.Dtos.ControleData;
using FortesAlimentacaoApi.Database.Dtos.DataObra;
using FortesAlimentacaoApi.Database.Dtos.Equipe;
using FortesAlimentacaoApi.Database.Dtos.Operario;

namespace FortesAlimentacaoApi.Database.Dtos.Refeicao;

public record RetornarRefeicao(
    Guid Id,
    RetornoEquipeRefeicao Equipe,
    bool Cafe,
    bool Almoco,
    bool Jantar,
    RetornoDataObraRefeicao DataObra
);