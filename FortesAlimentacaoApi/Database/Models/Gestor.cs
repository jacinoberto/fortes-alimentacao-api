using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Models;

[ComplexType]
[Index("Matricula", IsUnique = true)]
public class Gestor
{
    [Column("nome")]
    public required string Nome { get; set; }

    [Column("email")]
    public required string Email { get; set; }

    [Column("matricula")]
    public required string Matricula { get; set; }

    [Column("senha")]
    public required string Senha { get; set; }
}
