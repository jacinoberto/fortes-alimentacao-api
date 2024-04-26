using System.ComponentModel.DataAnnotations;

namespace FortesAlimentacaoApi.Database.Dtos.Operario;

public record InserirOperario(
    [Required(ErrorMessage = "A propriedade nome é obrigatória.")]
    string Nome,

    [Required(ErrorMessage = "A propriedade matricula e obrigatória.")]
    string Matricula
);
