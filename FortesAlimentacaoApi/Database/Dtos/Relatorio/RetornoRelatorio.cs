namespace FortesAlimentacaoApi.Database.Dtos.Relatorio;

public record RetornoRelatorio(
    string Encarregado,
    ICollection<Relatorio> Refeicoes,
    string Setor
);
