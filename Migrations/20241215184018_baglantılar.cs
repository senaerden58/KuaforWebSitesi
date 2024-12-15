using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class baglantılar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalisanSaatler_Calisanlar_CalisanID",
                table: "CalisanSaatler");

            migrationBuilder.DropForeignKey(
                name: "FK_CalisanSaatler_Gunler_GunID",
                table: "CalisanSaatler");

            migrationBuilder.AddForeignKey(
                name: "FK_CalisanSaatler_Calisanlar_CalisanID",
                table: "CalisanSaatler",
                column: "CalisanID",
                principalTable: "Calisanlar",
                principalColumn: "CalisanID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CalisanSaatler_Gunler_GunID",
                table: "CalisanSaatler",
                column: "GunID",
                principalTable: "Gunler",
                principalColumn: "GunID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalisanSaatler_Calisanlar_CalisanID",
                table: "CalisanSaatler");

            migrationBuilder.DropForeignKey(
                name: "FK_CalisanSaatler_Gunler_GunID",
                table: "CalisanSaatler");

            migrationBuilder.AddForeignKey(
                name: "FK_CalisanSaatler_Calisanlar_CalisanID",
                table: "CalisanSaatler",
                column: "CalisanID",
                principalTable: "Calisanlar",
                principalColumn: "CalisanID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalisanSaatler_Gunler_GunID",
                table: "CalisanSaatler",
                column: "GunID",
                principalTable: "Gunler",
                principalColumn: "GunID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
