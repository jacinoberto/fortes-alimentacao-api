namespace FortesAlimentacaoApi.Database.Dtos.Obra;

using FortesAlimentacaoApi.Database.Dtos.Endereco;

public record ObraSelectData(
    Guid Id,
    string Identificacao,
    EnderecoObra Endereco
 );
