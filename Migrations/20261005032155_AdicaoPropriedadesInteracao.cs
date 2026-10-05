using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskFlow.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoPropriedadesInteracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interacao");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_categorias",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "tb_interacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    autor = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    data_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mensagem = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ChamadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_interacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_interacoes_tb_chamados_ChamadoId",
                        column: x => x.ChamadoId,
                        principalTable: "tb_chamados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_interacoes_ChamadoId",
                table: "tb_interacoes",
                column: "ChamadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_interacoes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_categorias",
                newName: "id");

            migrationBuilder.CreateTable(
                name: "Interacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChamadoId = table.Column<int>(type: "int", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interacao_tb_chamados_ChamadoId",
                        column: x => x.ChamadoId,
                        principalTable: "tb_chamados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interacao_ChamadoId",
                table: "Interacao",
                column: "ChamadoId");
        }
    }
}
