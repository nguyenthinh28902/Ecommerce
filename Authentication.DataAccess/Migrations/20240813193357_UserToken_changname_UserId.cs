using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserToken_changname_UserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "UserTokens",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserTokens",
                newName: "IdentityUserId");
        }
    }
}
