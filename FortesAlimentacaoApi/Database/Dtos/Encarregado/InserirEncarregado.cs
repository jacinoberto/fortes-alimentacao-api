using FortesAlimentacaoApi.Database.Dtos.Gestor;

namespace FortesAlimentacaoApi.Database.Dtos.Encarregado;

public record InserirEncarregado(
    InserirGestor Gestor,
    bool Status = true
);
