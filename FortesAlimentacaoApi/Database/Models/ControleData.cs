using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Models;

[Table("tb_controle_datas")]
public class ControleData
{
    [Key]
    [Column("id_controle_data")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public  Guid Id { get; set; }

    [Column("data_refeicao")]
    public  DateOnly DataRefeicao { get; set; }

    [Column("descricao")]
    public string? Descricao { get; set; }

    [Column("atipico")]
    public  bool Atipico { get; set; }

    // Relacionamento
    public ICollection<Refeicao> Refeicoes { get; set; }
    public ICollection<DataObra> DataObras { get; set; }

}
