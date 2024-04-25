﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortesAlimentacaoApi.Database.Model;

[Table("tb_admins")]
public class Admin
{
    [Key]
    [Column("id_admin")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }

    public required Gestor Gestor { get; set; }

    [Column("status")]
    public required bool Status { get; set; }
}
