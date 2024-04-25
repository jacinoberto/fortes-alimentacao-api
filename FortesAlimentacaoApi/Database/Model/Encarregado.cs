using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Model;

[Table("tb_encarregados")]
public class Encarregado
{
    [Key]
    [Column("id_admin")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }

    public required Gestor Gestor { get; set; }

    // Relacionamento
    public ICollection<GestaoEquipe> GestaoEquipes { get; set; }
}
