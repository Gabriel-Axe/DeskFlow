using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskFlow.Migrations
{
    /// <inheritdoc />
    public partial class Conectar1ParaNCatEChamado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Chamados",
                table: "Chamados");

            migrationBuilder.RenameTable(
                name: "Chamados",
                newName: "tb_chamados");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "tb_chamados",
                newName: "titulo");

            migrationBuilder.AlterColumn<string>(
                name: "titulo",
                table: "tb_chamados",
                type: "varchar(128)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_chamados",
                table: "tb_chamados",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_chamados_CategoriaId",
                table: "tb_chamados",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_chamados_tb_categorias_CategoriaId",
                table: "tb_chamados",
                column: "CategoriaId",
                principalTable: "tb_categorias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_chamados_tb_categorias_CategoriaId",
                table: "tb_chamados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_chamados",
                table: "tb_chamados");

            migrationBuilder.DropIndex(
                name: "IX_tb_chamados_CategoriaId",
                table: "tb_chamados");

            migrationBuilder.RenameTable(
                name: "tb_chamados",
                newName: "Chamados");

            migrationBuilder.RenameColumn(
                name: "titulo",
                table: "Chamados",
                newName: "Titulo");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Chamados",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chamados",
                table: "Chamados",
                column: "Id");
        }
    }
}
