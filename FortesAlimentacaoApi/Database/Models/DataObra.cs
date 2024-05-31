using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Models;

[Table("tb_data_obras")]
public class DataObra
{
    [Key]
    [Column("id_data_obra")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("obra_id")]
    [ForeignKey(nameof(Obra))]
    public Guid ObraId { get; set; }

    [Column("controle_data_id")]
    [ForeignKey(nameof(ControleData))]
    public Guid ControleDataId { get; set; }

    public Obra Obra { get; set; }
    public ControleData ControleData { get; set; }

    public ICollection<Refeicao> Refeicoes { get; set; }
}
