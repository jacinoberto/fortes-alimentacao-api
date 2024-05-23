using FortesAlimentacaoApi.Database.Dtos.Gestor;

namespace FortesAlimentacaoApi.Database.Dtos.Encarregado;

public record RetornoEncarregadoLogin
 (
    Guid Id,
    GestorLogin Gestor
 );
