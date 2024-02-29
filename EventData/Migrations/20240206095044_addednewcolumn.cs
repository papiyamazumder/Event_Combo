using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventData.Migrations
{
    /// <inheritdoc />
    public partial class addednewcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventModels",
                table: "EventModel");

            migrationBuilder.RenameTable(
                name: "EventModel",
                newName: "EventModel");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "EventModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventModel",
                table: "EventModel",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventModel",
                table: "EventModel");

            migrationBuilder.DropColumn(
                name: "status",
                table: "EventModel");

            migrationBuilder.RenameTable(
                name: "EventModel",
                newName: "EventModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventModels",
                table: "EventModel",
                column: "Id");
        }
    }
}
