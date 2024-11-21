using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoFuncionarios.Module.Migrations
{
    /// <inheritdoc />
    public partial class Adicao_Cargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CargoID",
                table: "Funcionario",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CargoID",
                table: "Funcionario",
                column: "CargoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Cargos_CargoID",
                table: "Funcionario",
                column: "CargoID",
                principalTable: "Cargos",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Cargos_CargoID",
                table: "Funcionario");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_CargoID",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "CargoID",
                table: "Funcionario");
        }
    }
}
