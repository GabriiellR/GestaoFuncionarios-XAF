using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoFuncionarios.Module.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoDepartamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartamentoID",
                table: "Funcionario",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_DepartamentoID",
                table: "Funcionario",
                column: "DepartamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Departamento_DepartamentoID",
                table: "Funcionario",
                column: "DepartamentoID",
                principalTable: "Departamento",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Departamento_DepartamentoID",
                table: "Funcionario");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_DepartamentoID",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "DepartamentoID",
                table: "Funcionario");
        }
    }
}
