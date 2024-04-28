using FortesAlimentacaoApi.Database.Dtos.Encarregado;
using FortesAlimentacaoApi.Database.Dtos.Obra;

namespace FortesAlimentacaoApi.Database.Dtos.GestaoEquipe;

public record RetornarGestaoEquipe(
    Guid Id,
    RetornoObraGestao Obra,
    RetornoEncarregadoGestao Encarregado,
    string Setor
);
