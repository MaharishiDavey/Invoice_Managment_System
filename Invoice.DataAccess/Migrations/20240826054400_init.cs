using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Invoice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GSTNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillNo);
                    table.ForeignKey(
                        name: "FK_Bills_PartyDetails_PartyId",
                        column: x => x.PartyId,
                        principalTable: "PartyDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SNO = table.Column<int>(type: "int", nullable: false),
                    Particular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSNCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    BillNo = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillItems_Bills_BillNo",
                        column: x => x.BillNo,
                        principalTable: "Bills",
                        principalColumn: "BillNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PartyDetails",
                columns: new[] { "Id", "Address", "GSTNumber", "PartyName" },
                values: new object[,]
                {
                    { 1, "1234 Maple Street, Anytown, CA, 12345, USA", "27ABACB5678H1Z5", "Sweet Tooth Supply" },
                    { 2, "5678 Oak Avenue, Springfield, NY, 54321, USA", "36AAAC0001AB1Z5", "The Bread Basket" }
                });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillNo", "PartyId" },
                values: new object[,]
                {
                    { "B001", 2 },
                    { "B002", 1 },
                    { "B003", 1 },
                    { "B004", 2 }
                });

            migrationBuilder.InsertData(
                table: "BillItems",
                columns: new[] { "Id", "Amount", "BillNo", "HSNCode", "Particular", "Quantity", "Rate", "SNO" },
                values: new object[,]
                {
                    { 1, 40.0, "B001", "21436587", "Cake", 2, 20.0, 1 },
                    { 2, 50.0, "B001", "26843715", "Apple Pie", 1, 50.0, 2 },
                    { 3, 40.0, "B001", "43219876", "Cola", 1, 40.0, 3 },
                    { 4, 40.0, "B002", "21436587", "Cake", 2, 20.0, 1 },
                    { 5, 50.0, "B002", "26843715", "Apple Pie", 1, 50.0, 2 },
                    { 6, 40.0, "B003", "21436587", "Cake", 2, 20.0, 1 },
                    { 7, 50.0, "B003", "26843715", "Apple Pie", 1, 50.0, 2 },
                    { 8, 40.0, "B003", "43219876", "Cola", 1, 40.0, 3 },
                    { 9, 30.0, "B003", "94712586", "Ice Cream", 2, 15.0, 4 },
                    { 10, 40.0, "B004", "21436587", "Cake", 2, 20.0, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillItems_BillNo",
                table: "BillItems",
                column: "BillNo");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PartyId",
                table: "Bills",
                column: "PartyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillItems");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "PartyDetails");
        }
    }
}
