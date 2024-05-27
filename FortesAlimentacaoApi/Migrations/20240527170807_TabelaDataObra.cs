using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FortesAlimentacaoApi.Migrations
{
    /// <inheritdoc />
    public partial class TabelaDataObra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_data_obra",
                columns: table => new
                {
                    id_data_obra = table.Column<Guid>(type: "uuid", nullable: false),
                    obra_id = table.Column<Guid>(type: "uuid", nullable: false),
                    controle_data_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_data_obra", x => x.id_data_obra);
                    table.ForeignKey(
                        name: "FK_tb_data_obra_tb_controle_datas_controle_data_id",
                        column: x => x.controle_data_id,
                        principalTable: "tb_controle_datas",
                        principalColumn: "id_controle_data",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_data_obra_tb_obras_obra_id",
                        column: x => x.obra_id,
                        principalTable: "tb_obras",
                        principalColumn: "id_obra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_data_obra_controle_data_id",
                table: "tb_data_obra",
                column: "controle_data_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_data_obra_obra_id",
                table: "tb_data_obra",
                column: "obra_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_data_obra");
        }
    }
}
