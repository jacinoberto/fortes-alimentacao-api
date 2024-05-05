namespace FortesAlimentacaoApi.Database.Dtos.Refeicao;

public record AtualizarRefeicao(
    Guid Id,
    bool Cafe,
    bool Almoco,
    bool Jantar
);
