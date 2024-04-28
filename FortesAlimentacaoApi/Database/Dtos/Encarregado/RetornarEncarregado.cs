using FortesAlimentacaoApi.Database.Dtos.Gestor;

namespace FortesAlimentacaoApi.Database.Dtos.Encarregado;

public record RetornarEncarregado(
    Guid Id,
    RetornarGestor Gestor
);
