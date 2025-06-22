using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apicsharp.Migrations
{
    /// <inheritdoc />
    public partial class UserPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword("123456");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: hash);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuarios");
        }
    }
}
