using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KuaforWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class Eklemeler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MusteriTelefon",
                table: "Musteriler",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MusteriMail",
                table: "Musteriler",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Calisanlar",
                columns: new[] { "CalisanID", "CalisanAd", "CalisanMail", "CalisanSifre", "CalisanSoyad", "CalisanTelefon" },
                values: new object[,]
                {
                    { 1, "Dilan", "dilan.kaya@shineLab.com", "Dilan123", "Kaya", "05395456751" },
                    { 2, "Elif", "elif.yilmaz@shineLab.com", "Elif123", "Yılmaz", "05395456752" },
                    { 3, "Şeyma", "seyma.cetin@shineLab.com", "Seyma123", "Çetin", "05395456753" },
                    { 4, "Ece", "ece.tuncer@shineLab.com", "Ece123", "Tuncer", "05395456754" },
                    { 5, "Aslı", "asli.sahin@shineLab.com", "ShineLaB", "Şahin", "05395456755" },
                    { 6, "Ceyda", "ceyda.ozdemir@shineLab.com", "Ceyda123", "Özdemir", "05395456756" },
                    { 7, "Nisan", "nisan.kaya@shineLab.com", "Nisan123", "Kaya", "05395456757" }
                });

            migrationBuilder.InsertData(
                table: "CalisanGunler",
                columns: new[] { "CalisanGunID", "CalisanID", "GunID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 5 },
                    { 3, 2, 2 },
                    { 4, 2, 3 },
                    { 5, 2, 4 },
                    { 6, 2, 5 },
                    { 7, 2, 6 },
                    { 8, 3, 1 },
                    { 9, 3, 3 },
                    { 10, 3, 5 },
                    { 11, 3, 6 },
                    { 12, 4, 1 },
                    { 13, 4, 2 },
                    { 14, 4, 5 },
                    { 15, 4, 6 },
                    { 16, 5, 1 },
                    { 17, 5, 5 },
                    { 18, 5, 7 },
                    { 19, 6, 2 },
                    { 20, 6, 3 },
                    { 21, 6, 5 },
                    { 22, 6, 6 },
                    { 23, 6, 7 },
                    { 24, 7, 1 },
                    { 25, 7, 3 },
                    { 26, 7, 4 },
                    { 27, 7, 7 }
                });

            migrationBuilder.InsertData(
                table: "CalisanHizmetler",
                columns: new[] { "CalisanHizmetID", "CalisanID", "HizmetID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 1, 5 },
                    { 6, 1, 6 },
                    { 7, 1, 7 },
                    { 8, 1, 8 },
                    { 9, 1, 9 },
                    { 10, 1, 10 },
                    { 11, 1, 11 },
                    { 12, 1, 12 },
                    { 13, 1, 13 },
                    { 14, 1, 14 },
                    { 15, 1, 15 },
                    { 16, 1, 16 },
                    { 17, 2, 1 },
                    { 18, 2, 2 },
                    { 19, 2, 3 },
                    { 20, 2, 4 },
                    { 21, 2, 5 },
                    { 22, 2, 6 },
                    { 23, 2, 7 },
                    { 24, 2, 8 },
                    { 25, 2, 9 },
                    { 26, 2, 10 },
                    { 27, 2, 11 },
                    { 28, 2, 12 },
                    { 29, 2, 13 },
                    { 30, 2, 14 },
                    { 31, 2, 15 },
                    { 32, 2, 16 },
                    { 33, 3, 1 },
                    { 34, 3, 2 },
                    { 35, 3, 3 },
                    { 36, 3, 4 },
                    { 37, 3, 5 },
                    { 38, 3, 6 },
                    { 39, 3, 7 },
                    { 40, 3, 8 },
                    { 41, 3, 9 },
                    { 42, 3, 10 },
                    { 43, 3, 11 },
                    { 44, 3, 12 },
                    { 45, 3, 13 },
                    { 46, 3, 14 },
                    { 47, 4, 1 },
                    { 48, 4, 2 },
                    { 49, 4, 3 },
                    { 50, 4, 4 },
                    { 51, 4, 5 },
                    { 52, 4, 6 },
                    { 53, 4, 7 },
                    { 54, 4, 8 },
                    { 55, 4, 9 },
                    { 56, 4, 10 },
                    { 57, 4, 11 },
                    { 58, 4, 12 },
                    { 59, 4, 13 },
                    { 60, 4, 14 },
                    { 61, 4, 15 },
                    { 62, 4, 16 },
                    { 63, 4, 17 },
                    { 64, 4, 18 },
                    { 65, 4, 19 },
                    { 66, 4, 20 },
                    { 67, 4, 21 },
                    { 68, 4, 22 },
                    { 69, 4, 23 },
                    { 70, 4, 24 },
                    { 71, 5, 1 },
                    { 72, 5, 2 },
                    { 73, 5, 3 },
                    { 74, 5, 4 },
                    { 75, 5, 5 },
                    { 76, 6, 17 },
                    { 77, 6, 18 },
                    { 78, 6, 19 },
                    { 79, 6, 20 },
                    { 80, 6, 21 },
                    { 81, 6, 22 },
                    { 82, 6, 23 },
                    { 83, 6, 24 },
                    { 84, 7, 17 },
                    { 85, 7, 18 },
                    { 86, 7, 19 },
                    { 87, 7, 20 },
                    { 88, 7, 21 },
                    { 89, 7, 22 },
                    { 90, 7, 23 },
                    { 91, 7, 24 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_MusteriMail",
                table: "Musteriler",
                column: "MusteriMail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_MusteriTelefon",
                table: "Musteriler",
                column: "MusteriTelefon",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Musteriler_MusteriMail",
                table: "Musteriler");

            migrationBuilder.DropIndex(
                name: "IX_Musteriler_MusteriTelefon",
                table: "Musteriler");

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CalisanGunler",
                keyColumn: "CalisanGunID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "CalisanHizmetler",
                keyColumn: "CalisanHizmetID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Calisanlar",
                keyColumn: "CalisanID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Calisanlar",
                keyColumn: "CalisanID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Calisanlar",
                keyColumn: "CalisanID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Calisanlar",
                keyColumn: "CalisanID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Calisanlar",
                keyColumn: "CalisanID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Calisanlar",
                keyColumn: "CalisanID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Calisanlar",
                keyColumn: "CalisanID",
                keyValue: 7);

            migrationBuilder.AlterColumn<string>(
                name: "MusteriTelefon",
                table: "Musteriler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "MusteriMail",
                table: "Musteriler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
