using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FortesAlimentacaoApi.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoTabelaRefeicao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_refeicoes_tb_controle_datas_controle_data_id",
                table: "tb_refeicoes");

            migrationBuilder.DropColumn(
                name: "data",
                table: "tb_refeicoes");

            migrationBuilder.AlterColumn<Guid>(
                name: "controle_data_id",
                table: "tb_refeicoes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_refeicoes_tb_controle_datas_controle_data_id",
                table: "tb_refeicoes",
                column: "controle_data_id",
                principalTable: "tb_controle_datas",
                principalColumn: "id_controle_data",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_refeicoes_tb_controle_datas_controle_data_id",
                table: "tb_refeicoes");

            migrationBuilder.AlterColumn<Guid>(
                name: "controle_data_id",
                table: "tb_refeicoes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<DateOnly>(
                name: "data",
                table: "tb_refeicoes",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddForeignKey(
                name: "FK_tb_refeicoes_tb_controle_datas_controle_data_id",
                table: "tb_refeicoes",
                column: "controle_data_id",
                principalTable: "tb_controle_datas",
                principalColumn: "id_controle_data");
        }
    }
}
