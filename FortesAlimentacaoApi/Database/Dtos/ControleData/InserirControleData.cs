namespace FortesAlimentacaoApi.Database.Dtos.ControleData;

public record InserirControleData(
    DateOnly DataRefeicao,
    string? Descricao,
    bool Atipico
);
