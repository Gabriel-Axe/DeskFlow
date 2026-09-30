using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskFlow.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoAtributosAdicionaisChamados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_chamados_tb_categorias_CategoriaId",
                table: "tb_chamados");

            migrationBuilder.RenameColumn(
                name: "Solucao",
                table: "tb_chamados",
                newName: "solucao");

            migrationBuilder.RenameColumn(
                name: "Prioridade",
                table: "tb_chamados",
                newName: "prioridade");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "tb_chamados",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "SolicitanteNome",
                table: "tb_chamados",
                newName: "solicitante_nome");

            migrationBuilder.RenameColumn(
                name: "DataFechamento",
                table: "tb_chamados",
                newName: "data_fechamento");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "tb_chamados",
                newName: "categoria_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_chamados_CategoriaId",
                table: "tb_chamados",
                newName: "IX_tb_chamados_categoria_id");

            migrationBuilder.AlterColumn<string>(
                name: "solucao",
                table: "tb_chamados",
                type: "varchar(1024)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "tb_chamados",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "solicitante_nome",
                table: "tb_chamados",
                type: "varchar(64)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_fechamento",
                table: "tb_chamados",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_chamados_tb_categorias_categoria_id",
                table: "tb_chamados",
                column: "categoria_id",
                principalTable: "tb_categorias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_chamados_tb_categorias_categoria_id",
                table: "tb_chamados");

            migrationBuilder.RenameColumn(
                name: "solucao",
                table: "tb_chamados",
                newName: "Solucao");

            migrationBuilder.RenameColumn(
                name: "prioridade",
                table: "tb_chamados",
                newName: "Prioridade");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "tb_chamados",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "solicitante_nome",
                table: "tb_chamados",
                newName: "SolicitanteNome");

            migrationBuilder.RenameColumn(
                name: "data_fechamento",
                table: "tb_chamados",
                newName: "DataFechamento");

            migrationBuilder.RenameColumn(
                name: "categoria_id",
                table: "tb_chamados",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_chamados_categoria_id",
                table: "tb_chamados",
                newName: "IX_tb_chamados_CategoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "Solucao",
                table: "tb_chamados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(1024)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "tb_chamados",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "SolicitanteNome",
                table: "tb_chamados",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(64)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFechamento",
                table: "tb_chamados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_chamados_tb_categorias_CategoriaId",
                table: "tb_chamados",
                column: "CategoriaId",
                principalTable: "tb_categorias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
