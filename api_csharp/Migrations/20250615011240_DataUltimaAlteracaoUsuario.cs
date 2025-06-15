using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apicsharp.Migrations
{
    /// <inheritdoc />
    public partial class DataUltimaAlteracaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "Usuarios");
        }
    }
}
