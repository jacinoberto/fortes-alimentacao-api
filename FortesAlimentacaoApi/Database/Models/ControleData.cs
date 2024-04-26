using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Models;

[Table("tb_controle_datas")]
public class ControleData
{
    [Key]
    [Column("id_controle_data")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }

    [Column("data_refeicao")]
    public required DateTimeOffset DataRefeicao { get; set; }

    [Column("descricao")]
    public string? Descricao { get; set; }

    [Column("atipico")]
    public required bool Atipico { get; set; }

    // Relacionamento
    public ICollection<Refeicao> Refeicoes { get; set; }
}
