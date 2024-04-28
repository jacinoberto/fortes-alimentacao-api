using System.Globalization;

namespace FortesAlimentacaoApi.Database.Dtos.ControleData;

public record RetornarControleData(
    Guid Id,
    DateOnly DataRefeicao,
    string Descricao
);
