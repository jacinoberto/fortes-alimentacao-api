namespace FortesAlimentacaoApi.Database.Dtos.Gestor;

using System.ComponentModel.DataAnnotations;

public record InserirGestor (
    [Required(ErrorMessage = "A propriedade nome é obrigatória.")]
    string Nome,

    [Required(ErrorMessage = "A propriedade e-mail é obrigatória.")]
    string Email,

    [Required(ErrorMessage = "A propriedade matricula é obrigatória.")]
    string Matricula,

    [Required(ErrorMessage = "A propriedade senha é obrigatória.")]
    string Senha
);
