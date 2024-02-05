using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace casa_del_mar.Migrations
{
    /// <inheritdoc />
    public partial class ReservationDatesNewRowRoomID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservatedDates_Rooms_RoomID",
                table: "ReservatedDates");

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "ReservatedDates",
                newName: "roomID");

            migrationBuilder.RenameIndex(
                name: "IX_ReservatedDates_RoomID",
                table: "ReservatedDates",
                newName: "IX_ReservatedDates_roomID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservatedDates_Rooms_roomID",
                table: "ReservatedDates",
                column: "roomID",
                principalTable: "Rooms",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservatedDates_Rooms_roomID",
                table: "ReservatedDates");

            migrationBuilder.RenameColumn(
                name: "roomID",
                table: "ReservatedDates",
                newName: "RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_ReservatedDates_roomID",
                table: "ReservatedDates",
                newName: "IX_ReservatedDates_RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservatedDates_Rooms_RoomID",
                table: "ReservatedDates",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID");
        }
    }
}
