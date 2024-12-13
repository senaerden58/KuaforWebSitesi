using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KuaforWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class hizmet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hizmetler",
                columns: new[] { "HizmetID", "Fiyat", "HizmetAdi", "HizmetKategoriID", "Sure" },
                values: new object[,]
                {
                    { 1, 400m, "Fön", 2, new TimeSpan(0, 1, 0, 0, 0) },
                    { 2, 800m, "Maşa", 2, new TimeSpan(0, 1, 0, 0, 0) },
                    { 3, 1000m, "Örgü", 2, new TimeSpan(0, 1, 0, 0, 0) },
                    { 4, 1200m, "Topuz", 2, new TimeSpan(0, 1, 0, 0, 0) },
                    { 5, 1300m, "Saç Kesim", 2, new TimeSpan(0, 1, 0, 0, 0) },
                    { 6, 2500m, "Cila", 1, new TimeSpan(0, 0, 45, 0, 0) },
                    { 7, 1250m, "Dip Boya", 1, new TimeSpan(0, 1, 0, 0, 0) },
                    { 8, 1750m, "Transparan Boya", 1, new TimeSpan(0, 1, 0, 0, 0) },
                    { 9, 2500m, "Bütün Boya", 1, new TimeSpan(0, 2, 0, 0, 0) },
                    { 10, 5500m, "Brushlight", 1, new TimeSpan(0, 3, 0, 0, 0) },
                    { 11, 6000m, "Highlight", 1, new TimeSpan(0, 5, 0, 0, 0) },
                    { 12, 8000m, "Röfle", 1, new TimeSpan(0, 5, 0, 0, 0) },
                    { 13, 4000m, "Sakinleştirici Bakım", 1, new TimeSpan(0, 1, 30, 0, 0) },
                    { 14, 6000m, "Düzleştirici Bakım", 1, new TimeSpan(0, 2, 30, 0, 0) },
                    { 15, 6000m, "Gelin Saçı", 5, new TimeSpan(0, 3, 0, 0, 0) },
                    { 16, 6000m, "Gelin Makyajı", 5, new TimeSpan(0, 1, 30, 0, 0) },
                    { 17, 750m, "Manikür", 3, new TimeSpan(0, 0, 45, 0, 0) },
                    { 18, 750m, "Pedikür", 3, new TimeSpan(0, 0, 45, 0, 0) },
                    { 19, 550m, "El Kalıcı Oje", 3, new TimeSpan(0, 0, 45, 0, 0) },
                    { 20, 750m, "Ayak Kalıcı Oje", 3, new TimeSpan(0, 0, 45, 0, 0) },
                    { 21, 2500m, "Profesyonel Cilt Bakımı", 4, new TimeSpan(0, 1, 30, 0, 0) },
                    { 22, 400m, "Kaş Alımı", 4, new TimeSpan(0, 0, 20, 0, 0) },
                    { 23, 1250m, "Kirpik Lifting", 4, new TimeSpan(0, 0, 45, 0, 0) },
                    { 24, 1500m, "Karbon Peeling", 4, new TimeSpan(0, 0, 45, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 24);
        }
    }
}
