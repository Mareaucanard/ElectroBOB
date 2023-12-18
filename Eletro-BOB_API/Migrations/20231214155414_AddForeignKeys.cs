using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eletro_BOB_API.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_PreferenceId",
                table: "User",
                column: "PreferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_ActionId",
                table: "Area",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_ReactionId",
                table: "Area",
                column: "ReactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_ActionTrigger_ActionId",
                table: "Area",
                column: "ActionId",
                principalTable: "ActionTrigger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Area_ReactionTrigger_ReactionId",
                table: "Area",
                column: "ReactionId",
                principalTable: "ReactionTrigger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Preference_PreferenceId",
                table: "User",
                column: "PreferenceId",
                principalTable: "Preference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_ActionTrigger_ActionId",
                table: "Area");

            migrationBuilder.DropForeignKey(
                name: "FK_Area_ReactionTrigger_ReactionId",
                table: "Area");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Preference_PreferenceId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PreferenceId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Area_ActionId",
                table: "Area");

            migrationBuilder.DropIndex(
                name: "IX_Area_ReactionId",
                table: "Area");
        }
    }
}
