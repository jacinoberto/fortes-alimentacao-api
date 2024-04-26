using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FortesAlimentacaoApi.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoTabelaOperario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tb_operarios_matricula",
                table: "tb_operarios",
                column: "matricula",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_operarios_matricula",
                table: "tb_operarios");
        }
    }
}
