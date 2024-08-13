using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class usertoken_changName_IdentityUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_AspNetUsers_IdentotyUserId",
                table: "UserTokens");

            migrationBuilder.AlterColumn<string>(
                name: "IdentotyUserId",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "UserTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_AspNetUsers_IdentotyUserId",
                table: "UserTokens",
                column: "IdentotyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_AspNetUsers_IdentotyUserId",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "UserTokens");

            migrationBuilder.AlterColumn<string>(
                name: "IdentotyUserId",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_AspNetUsers_IdentotyUserId",
                table: "UserTokens",
                column: "IdentotyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
