using FortesAlimentacaoApi.Database.Dtos.Endereco;

namespace FortesAlimentacaoApi.Database.Dtos.Obra;

public record InserirObra(
    string Identificacao,
    EnderecoDto Endereco,
    DateOnly DataInicial
);
