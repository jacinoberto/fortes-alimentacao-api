namespace FortesAlimentacaoApi.Database.Dtos.Refeicao;

public record InserirRefeicao(
    Guid EquipeId,
    bool Cafe,
    bool Almoço,
    bool Jantar,
    Guid ControleDataId
);