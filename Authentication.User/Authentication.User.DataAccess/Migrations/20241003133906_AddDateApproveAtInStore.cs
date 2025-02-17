using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.User.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDateApproveAtInStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ApproveAt",
                schema: "sto",
                table: "Stores",
                type: "datetimeoffset",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproveAt",
                schema: "sto",
                table: "Stores");
        }
    }
}
