using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoFuncionarios.Module.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoTarefas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataFinalizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Assunto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PercentualConclusao = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioTarefa",
                columns: table => new
                {
                    FuncionariosID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TarefasID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioTarefa", x => new { x.FuncionariosID, x.TarefasID });
                    table.ForeignKey(
                        name: "FK_FuncionarioTarefa_Funcionario_FuncionariosID",
                        column: x => x.FuncionariosID,
                        principalTable: "Funcionario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionarioTarefa_Tarefas_TarefasID",
                        column: x => x.TarefasID,
                        principalTable: "Tarefas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioTarefa_TarefasID",
                table: "FuncionarioTarefa",
                column: "TarefasID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioTarefa");

            migrationBuilder.DropTable(
                name: "Tarefas");
        }
    }
}
