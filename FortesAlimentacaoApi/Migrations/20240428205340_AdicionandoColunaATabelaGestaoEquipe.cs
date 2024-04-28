using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FortesAlimentacaoApi.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoColunaATabelaGestaoEquipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "tb_gestao_equipes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "tb_gestao_equipes");
        }
    }
}
