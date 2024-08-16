using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealDelightAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUsersIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_UsersId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_UsersId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Recipes");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_UserId",
                table: "Recipes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_UserId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UsersId",
                table: "Recipes",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_UsersId",
                table: "Recipes",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
