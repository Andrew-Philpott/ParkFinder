using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace parksapi.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "park",
                columns: table => new
                {
                    ParkId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsNational = table.Column<bool>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_park", x => x.ParkId);
                });

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "park",
                columns: new[] { "ParkId", "IsNational", "Name", "StateId", "UserId" },
                values: new object[,]
                {
                    { 1, false, "Gulf State Park", 1, 0 },
                    { 14, true, "Olympic National Park", 47, 0 },
                    { 12, true, "Liberty Island", 32, 0 },
                    { 11, false, "Letchworth State Park", 32, 0 },
                    { 10, true, "Yosemite National Park", 5, 0 },
                    { 9, false, "Calaveras Big Trees State Park", 5, 0 },
                    { 8, true, "Hot Springs National Park", 4, 0 },
                    { 13, false, "Saint Edward State Park", 47, 0 },
                    { 6, true, "Grand Canyon National Park", 3, 0 },
                    { 5, false, "Cattali Cove State Park", 3, 0 },
                    { 4, true, "Kena Fjords National Park", 2, 0 },
                    { 3, false, "Chugach State Park", 2, 0 },
                    { 2, true, "Russel Cave National Monument", 1, 0 },
                    { 7, false, "Queen Wilhelmina State Park", 4, 0 }
                });

            migrationBuilder.InsertData(
                table: "state",
                columns: new[] { "StateId", "Name", "Region" },
                values: new object[,]
                {
                    { 35, "Ohio", "Midwest" },
                    { 34, "North Dakota", "Midwest" },
                    { 33, "North Carolina", "South" },
                    { 32, "New York", "Northeast" },
                    { 29, "New Hampshire", "Northeast" },
                    { 30, "New Jersey", "Northeast" },
                    { 28, "Nevada", "West" },
                    { 27, "Nebraska", "Midwest" },
                    { 36, "Oklahoma", "South" },
                    { 31, "New Mexico", "West" },
                    { 37, "Oregon", "West" },
                    { 44, "Utah", "West" },
                    { 39, "Rhode Island", "Northeast" },
                    { 40, "South Carolina", "South" },
                    { 41, "South Dakota", "Midwest" },
                    { 42, "Tennessee", "South" },
                    { 43, "Texas", "South" },
                    { 26, "Montana", "West" },
                    { 45, "Vermont", "Northeast" },
                    { 46, "Virginia", "South" },
                    { 47, "Washington", "West" },
                    { 48, "West Virginia", "South" },
                    { 38, "Pennsylvania", "Northeast" },
                    { 25, "Missouri", "Midwest" },
                    { 18, "Louisiana", "South" },
                    { 23, "Minnesota", "Midwest" },
                    { 1, "Alabama", "South" },
                    { 2, "Alaska", "West" },
                    { 3, "Arizona", "West" },
                    { 4, "Arkansas", "South" },
                    { 5, "California", "West" },
                    { 6, "Colorado", "West" },
                    { 7, "Connecticut", "West" },
                    { 8, "Delaware", "South" },
                    { 9, "Florida", "South" },
                    { 10, "Georgia", "South" },
                    { 24, "Mississippi", "South" },
                    { 11, "Hawaii", "West" },
                    { 13, "Illinois", "Midwest" },
                    { 14, "Indiana", "Midwest" },
                    { 15, "Iowa", "Midwest" },
                    { 16, "Kansas", "Midwest" },
                    { 17, "Kentucky", "South" },
                    { 49, "Wisconsin", "Midwest" },
                    { 19, "Maine", "West" },
                    { 20, "Maryland", "South" },
                    { 21, "Massachusetts", "Northeast" },
                    { 22, "Michigan", "Midwest" },
                    { 12, "Idaho", "West" },
                    { 50, "Wyoming", "West" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "park");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
