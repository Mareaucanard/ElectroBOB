using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eletro_BOB_API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDoubleForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Preference");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Preference",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
