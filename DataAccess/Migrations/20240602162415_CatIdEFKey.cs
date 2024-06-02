using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CatIdEFKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CatId",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CatId",
                value: 4);
        }
    }
}
