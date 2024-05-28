using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Models;

[Table("tb_refeicoes")]
public class Refeicao
{
    [Key]
    [Column("id_refeicao")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("equipe_id")]
    [ForeignKey(nameof(Equipe))]
    public Guid EquipeId { get; set; }

    [Column("cafe")]
    public bool Cafe { get; set; } = true;

    [Column("almoco")]
    public bool Almoco { get; set; } = true;

    [Column("jantar")]
    public bool Jantar { get; set; } = true;

    [Column("data_obra_id")]
    [ForeignKey(nameof(DataObra))]
    public Guid DataObraId { get; set; }

    // Relacionamentos
    public Equipe Equipe { get; set; }
    public DataObra DataObra { get; set; }
}
