using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.User.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addcolumIsApproveStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "sto",
                table: "Stores",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsApprove",
                schema: "sto",
                table: "Stores",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApprove",
                schema: "sto",
                table: "Stores");

            migrationBuilder.AlterColumn<string>(
                name: "IsActive",
                schema: "sto",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
