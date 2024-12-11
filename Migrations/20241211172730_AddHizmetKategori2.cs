using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class AddHizmetKategori2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HizmetKategoriID",
                table: "Hizmetler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hizmetler_HizmetKategoriID",
                table: "Hizmetler",
                column: "HizmetKategoriID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hizmetler_HizmetKategoriler_HizmetKategoriID",
                table: "Hizmetler",
                column: "HizmetKategoriID",
                principalTable: "HizmetKategoriler",
                principalColumn: "HizmetKategoriID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hizmetler_HizmetKategoriler_HizmetKategoriID",
                table: "Hizmetler");

            migrationBuilder.DropIndex(
                name: "IX_Hizmetler_HizmetKategoriID",
                table: "Hizmetler");

            migrationBuilder.DropColumn(
                name: "HizmetKategoriID",
                table: "Hizmetler");
        }
    }
}
