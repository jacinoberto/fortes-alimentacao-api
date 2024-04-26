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
    public bool Cafe { get; set; }

    [Column("almoco")]
    public bool Almoco { get; set; }

    [Column("jantar")]
    public bool Jantar { get; set; }

    [Column("controle_data_id")]
    [ForeignKey(nameof(ControleData))]
    public Guid ControleDataId { get; set; }

    // Relacionamentos
    public Equipe Equipe { get; set; }
    public ControleData ControleData { get; set; }
}
