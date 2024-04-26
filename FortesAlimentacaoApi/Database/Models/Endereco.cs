using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Models;

[Table("tb_enderecos")]
public class Endereco
{
    [Key]
    [Column("id_endereco")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }

    [Column("cep")]
    public required string Cep { get; set; }

    [Column("rua")]
    public required string Rua { get; set; }

    [Column("numero")]
    public int? Numero { get; set; }

    [Column("bairro")]
    public required string Bairro { get; set; }

    [Column("cidade")]
    public required string Cidade { get; set; }

    [Column("estado")]
    public required string Estado { get; set; }

    [Column("complemento")]
    public string? Complemento { get; set; }

    // Relacionamento
    public ICollection<Obra> Obras { get; set; }
}
