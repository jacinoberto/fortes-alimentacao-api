using FortesAlimentacaoApi.Database.Dtos.Endereco;

namespace FortesAlimentacaoApi.Database.Dtos.Obra;

public record RetornarObra(
    Guid Id,
    string Identificacao,
    EnderecoDto Endereco,
    DateOnly DataInicial,
    DateOnly DataFinal
);