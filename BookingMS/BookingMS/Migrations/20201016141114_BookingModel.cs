using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingMS.Migrations
{
    public partial class BookingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "User",
            //    columns: table => new
            //    {
            //        Username = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(nullable: false),
            //        Password = table.Column<string>(nullable: false),
            //        Contact_Number = table.Column<long>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_User", x => x.Username);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Vehicle",
            //    columns: table => new
            //    {
            //        VehicleID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Vehicle_Type = table.Column<string>(nullable: false),
            //        No_of_Seats = table.Column<int>(nullable: false),
            //        Cost_Per_Km = table.Column<int>(nullable: false),
            //        Number_InStock = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Vehicle", x => x.VehicleID);
            //    });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    VehicleID = table.Column<int>(nullable: false),
                    Date_of_Booking = table.Column<DateTime>(nullable: false),
                    Total_Km = table.Column<int>(nullable: false),
                    Total_Fare = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_Username",
                        column: x => x.Username,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Username",
                table: "Bookings",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VehicleID",
                table: "Bookings",
                column: "VehicleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            //migrationBuilder.DropTable(
            //    name: "User");

            //migrationBuilder.DropTable(
            //    name: "Vehicle");
        }
    }
}
