using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Models;

[Table("tb_obras")]
public class Obra
{
    [Key]
    [Column("id_obra")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }

    [Column("identificacao")]
    public required string Identificacao { get; set; }

    [Column("endereco_id")]
    [ForeignKey(nameof(Endereco))]
    public Guid EnderecoId { get; set; }

    [Column("data_inicial")]
    public DateOnly DataInicial { get; set; }

    [Column("data_final")]
    public DateOnly? DataFinal { get; set; }

    // Relacionamentos
    public Endereco Endereco { get; set; }
    public ICollection<GestaoEquipe>? GestaoEquipes { get; set; }
    public ICollection<DataObra> DataObras { get; set; }
}
