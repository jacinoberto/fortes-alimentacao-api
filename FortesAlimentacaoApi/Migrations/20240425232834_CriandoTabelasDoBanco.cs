using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FortesAlimentacaoApi.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelasDoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_admins",
                columns: table => new
                {
                    id_admin = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    matricula = table.Column<string>(type: "text", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_admins", x => x.id_admin);
                });

            migrationBuilder.CreateTable(
                name: "tb_controle_datas",
                columns: table => new
                {
                    id_controle_data = table.Column<Guid>(type: "uuid", nullable: false),
                    data_refeicao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    atipico = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_controle_datas", x => x.id_controle_data);
                });

            migrationBuilder.CreateTable(
                name: "tb_encarregados",
                columns: table => new
                {
                    id_admin = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    matricula = table.Column<string>(type: "text", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_encarregados", x => x.id_admin);
                });

            migrationBuilder.CreateTable(
                name: "tb_enderecos",
                columns: table => new
                {
                    id_endereco = table.Column<Guid>(type: "uuid", nullable: false),
                    cep = table.Column<string>(type: "text", nullable: false),
                    rua = table.Column<string>(type: "text", nullable: false),
                    numero = table.Column<int>(type: "integer", nullable: true),
                    bairro = table.Column<string>(type: "text", nullable: false),
                    cidade = table.Column<string>(type: "text", nullable: false),
                    estado = table.Column<string>(type: "text", nullable: false),
                    complemento = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_enderecos", x => x.id_endereco);
                });

            migrationBuilder.CreateTable(
                name: "tb_operarios",
                columns: table => new
                {
                    id_operario = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    matricula = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_operarios", x => x.id_operario);
                });

            migrationBuilder.CreateTable(
                name: "tb_obras",
                columns: table => new
                {
                    id_obra = table.Column<Guid>(type: "uuid", nullable: false),
                    identificacao = table.Column<string>(type: "text", nullable: false),
                    endereco_id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_inicial = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data_final = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_obras", x => x.id_obra);
                    table.ForeignKey(
                        name: "FK_tb_obras_tb_enderecos_endereco_id",
                        column: x => x.endereco_id,
                        principalTable: "tb_enderecos",
                        principalColumn: "id_endereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_gestao_equipes",
                columns: table => new
                {
                    id_gestao_equipe = table.Column<Guid>(type: "uuid", nullable: false),
                    obra_id = table.Column<Guid>(type: "uuid", nullable: false),
                    encarregado_id = table.Column<Guid>(type: "uuid", nullable: false),
                    setor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_gestao_equipes", x => x.id_gestao_equipe);
                    table.ForeignKey(
                        name: "FK_tb_gestao_equipes_tb_encarregados_encarregado_id",
                        column: x => x.encarregado_id,
                        principalTable: "tb_encarregados",
                        principalColumn: "id_admin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_gestao_equipes_tb_obras_obra_id",
                        column: x => x.obra_id,
                        principalTable: "tb_obras",
                        principalColumn: "id_obra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_equipes",
                columns: table => new
                {
                    id_equipe = table.Column<Guid>(type: "uuid", nullable: false),
                    gestao_equipe_id = table.Column<Guid>(type: "uuid", nullable: false),
                    operario_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_equipes", x => x.id_equipe);
                    table.ForeignKey(
                        name: "FK_tb_equipes_tb_gestao_equipes_gestao_equipe_id",
                        column: x => x.gestao_equipe_id,
                        principalTable: "tb_gestao_equipes",
                        principalColumn: "id_gestao_equipe",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_equipes_tb_operarios_operario_id",
                        column: x => x.operario_id,
                        principalTable: "tb_operarios",
                        principalColumn: "id_operario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_refeicoes",
                columns: table => new
                {
                    id_refeicao = table.Column<Guid>(type: "uuid", nullable: false),
                    equipe_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cafe = table.Column<bool>(type: "boolean", nullable: false),
                    almoco = table.Column<bool>(type: "boolean", nullable: false),
                    jantar = table.Column<bool>(type: "boolean", nullable: false),
                    controle_data_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_refeicoes", x => x.id_refeicao);
                    table.ForeignKey(
                        name: "FK_tb_refeicoes_tb_controle_datas_controle_data_id",
                        column: x => x.controle_data_id,
                        principalTable: "tb_controle_datas",
                        principalColumn: "id_controle_data",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_refeicoes_tb_equipes_equipe_id",
                        column: x => x.equipe_id,
                        principalTable: "tb_equipes",
                        principalColumn: "id_equipe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_equipes_gestao_equipe_id",
                table: "tb_equipes",
                column: "gestao_equipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_equipes_operario_id",
                table: "tb_equipes",
                column: "operario_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_gestao_equipes_encarregado_id",
                table: "tb_gestao_equipes",
                column: "encarregado_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_gestao_equipes_obra_id",
                table: "tb_gestao_equipes",
                column: "obra_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_obras_endereco_id",
                table: "tb_obras",
                column: "endereco_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_refeicoes_controle_data_id",
                table: "tb_refeicoes",
                column: "controle_data_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_refeicoes_equipe_id",
                table: "tb_refeicoes",
                column: "equipe_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_admins");

            migrationBuilder.DropTable(
                name: "tb_refeicoes");

            migrationBuilder.DropTable(
                name: "tb_controle_datas");

            migrationBuilder.DropTable(
                name: "tb_equipes");

            migrationBuilder.DropTable(
                name: "tb_gestao_equipes");

            migrationBuilder.DropTable(
                name: "tb_operarios");

            migrationBuilder.DropTable(
                name: "tb_encarregados");

            migrationBuilder.DropTable(
                name: "tb_obras");

            migrationBuilder.DropTable(
                name: "tb_enderecos");
        }
    }
}
