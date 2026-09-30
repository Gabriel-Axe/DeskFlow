using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskFlow.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoEsquemaFinalPrototipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Conteudo",
                table: "Interacao",
                newName: "Mensagem");

            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Interacao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRegistro",
                table: "Interacao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Interacao");

            migrationBuilder.DropColumn(
                name: "DataRegistro",
                table: "Interacao");

            migrationBuilder.RenameColumn(
                name: "Mensagem",
                table: "Interacao",
                newName: "Conteudo");
        }
    }
}
