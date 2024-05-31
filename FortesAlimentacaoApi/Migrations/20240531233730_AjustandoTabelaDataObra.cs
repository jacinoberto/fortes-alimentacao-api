using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FortesAlimentacaoApi.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoTabelaDataObra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_data_obra_tb_controle_datas_controle_data_id",
                table: "tb_data_obra");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_data_obra_tb_obras_obra_id",
                table: "tb_data_obra");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_refeicoes_tb_data_obra_data_obra_id",
                table: "tb_refeicoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_data_obra",
                table: "tb_data_obra");

            migrationBuilder.RenameTable(
                name: "tb_data_obra",
                newName: "tb_data_obras");

            migrationBuilder.RenameIndex(
                name: "IX_tb_data_obra_obra_id",
                table: "tb_data_obras",
                newName: "IX_tb_data_obras_obra_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_data_obra_controle_data_id",
                table: "tb_data_obras",
                newName: "IX_tb_data_obras_controle_data_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_data_obras",
                table: "tb_data_obras",
                column: "id_data_obra");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_data_obras_tb_controle_datas_controle_data_id",
                table: "tb_data_obras",
                column: "controle_data_id",
                principalTable: "tb_controle_datas",
                principalColumn: "id_controle_data",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_data_obras_tb_obras_obra_id",
                table: "tb_data_obras",
                column: "obra_id",
                principalTable: "tb_obras",
                principalColumn: "id_obra",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_refeicoes_tb_data_obras_data_obra_id",
                table: "tb_refeicoes",
                column: "data_obra_id",
                principalTable: "tb_data_obras",
                principalColumn: "id_data_obra",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_data_obras_tb_controle_datas_controle_data_id",
                table: "tb_data_obras");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_data_obras_tb_obras_obra_id",
                table: "tb_data_obras");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_refeicoes_tb_data_obras_data_obra_id",
                table: "tb_refeicoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_data_obras",
                table: "tb_data_obras");

            migrationBuilder.RenameTable(
                name: "tb_data_obras",
                newName: "tb_data_obra");

            migrationBuilder.RenameIndex(
                name: "IX_tb_data_obras_obra_id",
                table: "tb_data_obra",
                newName: "IX_tb_data_obra_obra_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_data_obras_controle_data_id",
                table: "tb_data_obra",
                newName: "IX_tb_data_obra_controle_data_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_data_obra",
                table: "tb_data_obra",
                column: "id_data_obra");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_data_obra_tb_controle_datas_controle_data_id",
                table: "tb_data_obra",
                column: "controle_data_id",
                principalTable: "tb_controle_datas",
                principalColumn: "id_controle_data",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_data_obra_tb_obras_obra_id",
                table: "tb_data_obra",
                column: "obra_id",
                principalTable: "tb_obras",
                principalColumn: "id_obra",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_refeicoes_tb_data_obra_data_obra_id",
                table: "tb_refeicoes",
                column: "data_obra_id",
                principalTable: "tb_data_obra",
                principalColumn: "id_data_obra",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
