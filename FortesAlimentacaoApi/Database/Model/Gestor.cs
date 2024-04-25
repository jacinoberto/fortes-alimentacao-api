using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Model;

[ComplexType]
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
