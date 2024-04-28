using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Models;

[Table("tb_encarregados")]
public class Encarregado
{
    [Key]
    [Column("id_encarregado")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }

    public required Gestor Gestor { get; set; }

    // Relacionamento
    public ICollection<GestaoEquipe> GestaoEquipes { get; set; }

    // Metodos
    public void InativarPerfil()
    {
        Gestor.Status = false;
    }
}
