using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.User.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDateIsActionInApplicationLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAction",
                schema: "dbo",
                table: "ApplicationLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAction",
                schema: "dbo",
                table: "ApplicationLogs");
        }
    }
}
