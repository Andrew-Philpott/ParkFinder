using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace parksapi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Region = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "park",
                columns: table => new
                {
                    ParkId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    IsNational = table.Column<bool>(nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_park", x => x.ParkId);
                    table.ForeignKey(
                        name: "FK_park_state_StateId",
                        column: x => x.StateId,
                        principalTable: "state",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "state",
                columns: new[] { "StateId", "Name", "Region" },
                values: new object[,]
                {
                    { 1, "Alabama", "South" },
                    { 28, "Nevada", "West" },
                    { 29, "New Hampshire", "Northeast" },
                    { 30, "New Jersey", "Northeast" },
                    { 31, "New Mexico", "West" },
                    { 32, "New York", "Northeast" },
                    { 33, "North Carolina", "South" },
                    { 34, "North Dakota", "Midwest" },
                    { 35, "Ohio", "Midwest" },
                    { 36, "Oklahoma", "South" },
                    { 37, "Oregon", "West" },
                    { 38, "Pennsylvania", "Northeast" },
                    { 39, "Rhode Island", "Northeast" },
                    { 40, "South Carolina", "South" },
                    { 41, "South Dakota", "Midwest" },
                    { 42, "Tennessee", "South" },
                    { 43, "Texas", "South" },
                    { 44, "Utah", "West" },
                    { 45, "Vermont", "Northeast" },
                    { 46, "Virginia", "South" },
                    { 47, "Washington", "West" },
                    { 48, "West Virginia", "South" },
                    { 27, "Nebraska", "Midwest" },
                    { 26, "Montana", "West" },
                    { 25, "Missouri", "Midwest" },
                    { 24, "Mississippi", "South" },
                    { 2, "Alaska", "West" },
                    { 3, "Arizona", "West" },
                    { 4, "Arkansas", "South" },
                    { 5, "California", "West" },
                    { 6, "Colorado", "West" },
                    { 7, "Connecticut", "West" },
                    { 8, "Delaware", "South" },
                    { 9, "Florida", "South" },
                    { 10, "Georgia", "South" },
                    { 11, "Hawaii", "West" },
                    { 49, "Wisconsin", "Midwest" },
                    { 12, "Idaho", "West" },
                    { 14, "Indiana", "Midwest" },
                    { 15, "Iowa", "Midwest" },
                    { 16, "Kansas", "Midwest" },
                    { 17, "Kentucky", "South" },
                    { 18, "Louisiana", "South" },
                    { 19, "Maine", "West" },
                    { 20, "Maryland", "South" },
                    { 21, "Massachusetts", "Northeast" },
                    { 22, "Michigan", "Midwest" },
                    { 23, "Minnesota", "Midwest" },
                    { 13, "Illinois", "Midwest" },
                    { 50, "Wyoming", "West" }
                });

            migrationBuilder.InsertData(
                table: "park",
                columns: new[] { "ParkId", "IsNational", "Name", "StateId" },
                values: new object[,]
                {
                    { 1, false, "Gulf State Park", 1 },
                    { 2, true, "Russel Cave National Monument", 1 },
                    { 3, false, "Chugach State Park", 2 },
                    { 4, true, "Kena Fjords National Park", 2 },
                    { 5, false, "Cattali Cove State Park", 3 },
                    { 6, true, "Grand Canyon National Park", 3 },
                    { 7, false, "Queen Wilhelmina State Park", 4 },
                    { 8, true, "Hot Springs National Park", 4 },
                    { 9, false, "Calaveras Big Trees State Park", 5 },
                    { 10, true, "Yosemite National Park", 5 },
                    { 11, false, "Letchworth State Park", 32 },
                    { 12, true, "Liberty Island", 32 },
                    { 13, false, "Saint Edward State Park", 47 },
                    { 14, true, "Olympic National Park", 47 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_park_StateId",
                table: "park",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "park");

            migrationBuilder.DropTable(
                name: "state");
        }
    }
}
