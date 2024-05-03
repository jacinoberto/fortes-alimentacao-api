namespace FortesAlimentacaoApi.Database.Dtos.ControleData;

public record RetornoControleDataRefeicao(
    DateOnly DataRefeicao,
    string Descricao,
    bool Atipico
);
