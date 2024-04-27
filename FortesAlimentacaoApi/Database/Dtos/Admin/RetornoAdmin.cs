namespace FortesAlimentacaoApi.Database.Dtos.Admin;

using FortesAlimentacaoApi.Database.Dtos.Gestor;

public record RetornoAdmin(
    Guid Id,
    RetornarGestor Gestor
);
