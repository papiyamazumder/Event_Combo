using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventData.Migrations
{
    /// <inheritdoc />
    public partial class EventBookingname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventBooking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventBooking_EventModel_EventId",
                        column: x => x.EventId,
                        principalTable: "EventModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventBooking_UserModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventBooking_EventId",
                table: "EventBooking",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventBooking_UserId",
                table: "EventBooking",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventBooking");
        }
    }
}
