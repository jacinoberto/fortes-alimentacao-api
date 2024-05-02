using FortesAlimentacaoApi.Database.Dtos.Gestor;

namespace FortesAlimentacaoApi.Database.Dtos.Encarregado;

public record RetornoEncarregadoSelect(
    Guid Id,
    GestorSelect Gestor
);
