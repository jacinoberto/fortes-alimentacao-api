
using FortesAlimentacaoApi.Database.Dtos.Encarregado;
using FortesAlimentacaoApi.Database.Dtos.Obra;

namespace FortesAlimentacaoApi.Database.Dtos.GestaoEquipe;

public record GestaoEquipeSelect
(
    Guid Id,
    RetornoEncarregadoGestaoSelect Encarregado,
    RetornoObraGestao Obra,
    string Setor
);


