using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeBillItemsAmountColum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "BillItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "BillItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 40.0);

            migrationBuilder.UpdateData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Amount",
                value: 50.0);

            migrationBuilder.UpdateData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Amount",
                value: 40.0);

            migrationBuilder.UpdateData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Amount",
                value: 40.0);

            migrationBuilder.UpdateData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Amount",
                value: 50.0);

            migrationBuilder.UpdateData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Amount",
                value: 40.0);

            migrationBuilder.UpdateData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Amount",
                value: 50.0);

            migrationBuilder.UpdateData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Amount",
                value: 40.0);

            migrationBuilder.UpdateData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "Amount",
                value: 30.0);

            migrationBuilder.UpdateData(
                table: "BillItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "Amount",
                value: 40.0);
        }
    }
}
