using System.ComponentModel.DataAnnotations;

namespace FortesAlimentacaoApi.Database.Dtos.Endereco;

public record EnderecoDto(
    [Required(ErrorMessage = "O campo Cep é obrigatório.")]
    string Cep,

    [Required(ErrorMessage = "O campo Rua é obrigatório.")]
    string Rua,

    int Numero,

    string Complemento,

    [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
    string Bairro,

    [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
    string Cidade,

    [Required(ErrorMessage = "O campo Estado é obrigatório.")]
    string Estado
);
