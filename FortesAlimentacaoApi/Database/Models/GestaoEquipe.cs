using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Models;

[Table("tb_gestao_equipes")]
public class GestaoEquipe
{
    [Key]
    [Column("id_gestao_equipe")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }

    [Column("obra_id")]
    [ForeignKey(nameof(Obra))]
    public required Guid ObraId { get; set; }

    [Column("encarregado_id")]
    [ForeignKey(nameof(Models.Encarregado))]
    public required Guid EncarregadoId { get; set; }

    [Column("setor")]
    public required string Setor { get; set; }

    [Column("status")]
    public required bool Status { get; set; } = true;

    // Relacionamentos
    public Obra Obra { get; set; }
    public Encarregado Encarregado { get; set; }
    public ICollection<Equipe> Equipes { get; set; }

    // Métodos
    public void InativarGestaoEquipe()
    {
        Status = false;
    }
}
