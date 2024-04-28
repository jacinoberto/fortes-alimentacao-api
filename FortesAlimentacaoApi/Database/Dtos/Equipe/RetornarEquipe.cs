using FortesAlimentacaoApi.Database.Dtos.GestaoEquipe;
using FortesAlimentacaoApi.Database.Dtos.Operario;

namespace FortesAlimentacaoApi.Database.Dtos.Equipe;

public record RetornarEquipe(
    Guid Id,
    RetornarGestaoEquipe GestaoEquipe,
    RetornoOperarioEquipe Operario
);
