using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace casa_del_mar.Migrations
{
    /// <inheritdoc />
    public partial class RenameReservationDatesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IReservationDates");

            migrationBuilder.CreateTable(
                name: "ReservatedDates",
                columns: table => new
                {
                    reservationDatesID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    end = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RoomID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservatedDates", x => x.reservationDatesID);
                    table.ForeignKey(
                        name: "FK_ReservatedDates_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservatedDates_RoomID",
                table: "ReservatedDates",
                column: "RoomID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservatedDates");

            migrationBuilder.CreateTable(
                name: "IReservationDates",
                columns: table => new
                {
                    reservationDatesID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomID = table.Column<int>(type: "integer", nullable: true),
                    end = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    start = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IReservationDates", x => x.reservationDatesID);
                    table.ForeignKey(
                        name: "FK_IReservationDates_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IReservationDates_RoomID",
                table: "IReservationDates",
                column: "RoomID");
        }
    }
}
