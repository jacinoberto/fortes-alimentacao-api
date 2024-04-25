using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Model;

[Table("tb_equipes")]
public class Equipe
{
    [Key]
    [Column("id_equipe")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }

    [Column("gestao_equipe_id")]
    [ForeignKey(nameof(GestaoEquipe))]
    public required Guid GestaoEquipeId { get; set; }

    [Column("operario_id")]
    [ForeignKey(nameof(Operario))]
    public required Guid OperarioID { get; set; }

    // Relacionamentos
    public GestaoEquipe GestaoEquipe { get; set; }
    public Operario Operario { get; set; }
    public ICollection<Refeicao> Refeicoes { get; set; }
}
