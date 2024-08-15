using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserToken_changname_UserId_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_AspNetUsers_IdentotyUserId",
                table: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserTokens_IdentotyUserId",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "IdentotyUserId",
                table: "UserTokens");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_AspNetUsers_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_AspNetUsers_UserId",
                table: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTokens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IdentotyUserId",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_IdentotyUserId",
                table: "UserTokens",
                column: "IdentotyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_AspNetUsers_IdentotyUserId",
                table: "UserTokens",
                column: "IdentotyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
