namespace FortesAlimentacaoApi.Database.Dtos.Relatorio;

public record Relatorio(
    DateOnly DataRefeicao,
    int Cafe,
    int Almoco,
    int Jantar
);
