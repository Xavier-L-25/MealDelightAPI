using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealDelightAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserCredentialEmailPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCredentials",
                table: "UserCredentials");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserCredentials",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCredentials",
                table: "UserCredentials",
                columns: new[] { "UserId", "Email" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCredentials",
                table: "UserCredentials");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserCredentials",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCredentials",
                table: "UserCredentials",
                column: "UserId");
        }
    }
}
