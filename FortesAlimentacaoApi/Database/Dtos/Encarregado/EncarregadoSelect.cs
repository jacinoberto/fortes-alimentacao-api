using FortesAlimentacaoApi.Database.Dtos.Gestor;

namespace FortesAlimentacaoApi.Database.Dtos.Encarregado;

public record EncarregadoSelect(
    Guid Id,
    GestorSelect Gestor
);
