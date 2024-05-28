using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FortesAlimentacaoApi.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoRelacionamentoEntreRefeicoesEDataObra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_refeicoes_tb_controle_datas_controle_data_id",
                table: "tb_refeicoes");

            migrationBuilder.RenameColumn(
                name: "controle_data_id",
                table: "tb_refeicoes",
                newName: "data_obra_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_refeicoes_controle_data_id",
                table: "tb_refeicoes",
                newName: "IX_tb_refeicoes_data_obra_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_refeicoes_tb_data_obra_data_obra_id",
                table: "tb_refeicoes",
                column: "data_obra_id",
                principalTable: "tb_data_obra",
                principalColumn: "id_data_obra",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_refeicoes_tb_data_obra_data_obra_id",
                table: "tb_refeicoes");

            migrationBuilder.RenameColumn(
                name: "data_obra_id",
                table: "tb_refeicoes",
                newName: "controle_data_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_refeicoes_data_obra_id",
                table: "tb_refeicoes",
                newName: "IX_tb_refeicoes_controle_data_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_refeicoes_tb_controle_datas_controle_data_id",
                table: "tb_refeicoes",
                column: "controle_data_id",
                principalTable: "tb_controle_datas",
                principalColumn: "id_controle_data",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
