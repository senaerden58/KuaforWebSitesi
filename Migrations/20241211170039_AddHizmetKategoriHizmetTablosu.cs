using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class AddHizmetKategoriHizmetTablosu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalisanHizmetler",
                columns: table => new
                {
                    CalisanHizmetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalisanID = table.Column<int>(type: "int", nullable: false),
                    HizmetID = table.Column<int>(type: "int", nullable: false),
                    HizmetlerHizmetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalisanHizmetler", x => x.CalisanHizmetID);
                    table.ForeignKey(
                        name: "FK_CalisanHizmetler_Calisanlar_CalisanID",
                        column: x => x.CalisanID,
                        principalTable: "Calisanlar",
                        principalColumn: "CalisanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalisanHizmetler_Hizmetler_HizmetlerHizmetID",
                        column: x => x.HizmetlerHizmetID,
                        principalTable: "Hizmetler",
                        principalColumn: "HizmetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalisanHizmetler_CalisanID",
                table: "CalisanHizmetler",
                column: "CalisanID");

            migrationBuilder.CreateIndex(
                name: "IX_CalisanHizmetler_HizmetlerHizmetID",
                table: "CalisanHizmetler",
                column: "HizmetlerHizmetID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalisanHizmetler");
        }
    }
}
