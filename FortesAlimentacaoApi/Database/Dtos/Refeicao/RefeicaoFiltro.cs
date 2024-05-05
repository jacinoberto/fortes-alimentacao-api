namespace FortesAlimentacaoApi.Database.Dtos.Refeicao;

using FortesAlimentacaoApi.Database.Models;

public record RefeicaoFiltro(
    Refeicao Refeicao,
    AtualizarRefeicao AtualizarRefeicao
);