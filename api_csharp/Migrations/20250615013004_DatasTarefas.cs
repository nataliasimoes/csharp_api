using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apicsharp.Migrations
{
    /// <inheritdoc />
    public partial class DatasTarefas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataConclusao",
                table: "Tarefas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrazo",
                table: "Tarefas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "Tarefas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataConclusao",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "DataPrazo",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "Tarefas");
        }
    }
}
