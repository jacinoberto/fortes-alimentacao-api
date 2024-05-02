using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Models;

[Table("tb_operarios")]
public class Operario
{
    [Key]
    [Column("id_operario")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }

    [Column("nome")]
    public required string Nome { get; set; }

    [Column("matricula")]
    public required string Matricula { get; set; }

    [Column("status")]
    public required bool Status { get; set; } = true;

    // Relacionamento
    public ICollection<Equipe> Equipes { get; set; }

    // Métodos
    public void InativarPerfil()
    {
        Status = false;
    }
}
