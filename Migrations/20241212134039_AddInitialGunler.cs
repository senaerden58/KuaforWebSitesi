using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KuaforWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialGunler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gunler",
                columns: new[] { "GunID", "GunAdi" },
                values: new object[,]
                {
                    { 1, "Pazartesi" },
                    { 2, "Salı" },
                    { 3, "Çarşamba" },
                    { 4, "Perşembe" },
                    { 5, "Cuma" },
                    { 6, "Cumartesi" },
                    { 7, "Pazar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gunler",
                keyColumn: "GunID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gunler",
                keyColumn: "GunID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gunler",
                keyColumn: "GunID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Gunler",
                keyColumn: "GunID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Gunler",
                keyColumn: "GunID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Gunler",
                keyColumn: "GunID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Gunler",
                keyColumn: "GunID",
                keyValue: 7);
        }
    }
}
