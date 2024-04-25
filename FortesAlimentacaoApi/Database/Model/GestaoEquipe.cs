using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Model;

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
    [ForeignKey(nameof(Encarregado))]
    public required Guid EncarregadoId { get; set; }

    [Column("setor")]
    public required string Setor { get; set; }

    // Relacionamentos
    public Obra Obra { get; set; }
    public Encarregado Encarregrado { get; set; }
    public ICollection<Equipe> Equipes { get; set; }
}
