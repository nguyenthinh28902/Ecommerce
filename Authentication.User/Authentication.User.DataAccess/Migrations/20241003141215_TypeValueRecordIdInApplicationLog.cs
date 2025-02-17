using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.User.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TypeValueRecordIdInApplicationLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RecordId",
                schema: "dbo",
                table: "ApplicationLogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RecordId",
                schema: "dbo",
                table: "ApplicationLogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
