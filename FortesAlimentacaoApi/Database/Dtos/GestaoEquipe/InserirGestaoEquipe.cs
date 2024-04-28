namespace FortesAlimentacaoApi.Database.Dtos.GestaoEquipe;

public record InserirGestaoEquipe(
    Guid ObraId,
    Guid EncarregadoId,
    string Setor
);
