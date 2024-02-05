using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace casa_del_mar.Migrations
{
    /// <inheritdoc />
    public partial class RoomDeleteRowReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservatedDates_Rooms_roomID",
                table: "ReservatedDates");

            migrationBuilder.DropIndex(
                name: "IX_ReservatedDates_roomID",
                table: "ReservatedDates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReservatedDates_roomID",
                table: "ReservatedDates",
                column: "roomID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservatedDates_Rooms_roomID",
                table: "ReservatedDates",
                column: "roomID",
                principalTable: "Rooms",
                principalColumn: "ID");
        }
    }
}
