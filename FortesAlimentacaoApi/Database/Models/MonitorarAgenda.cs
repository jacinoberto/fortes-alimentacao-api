using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Models;

[Table("tb_monitorar_agendas")]
public class MonitorarAgenda
{
    [Key]
    [Column("id_monitorar_agenda")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("data_abertura")]
    public DateOnly data_abertura { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    [Column("status")]
    public string Status { get; set; } = "Processando";

    [Column("checado")]
    public bool Checkado { get; set; } = false;
}
