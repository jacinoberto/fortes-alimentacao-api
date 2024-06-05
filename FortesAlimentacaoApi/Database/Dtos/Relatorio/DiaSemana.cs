namespace FortesAlimentacaoApi.Database.Dtos.Relatorio;

public record DiaSemana(
    DateOnly? DataInicial,
    DateOnly? DataFinal
);
