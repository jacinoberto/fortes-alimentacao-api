using FortesAlimentacaoApi.Database.Dtos.Gestor;

namespace FortesAlimentacaoApi.Database.Dtos.Admin;

public record RetornoAdminLogin
(
    Guid Id,
    GestorLogin Gestor
);
