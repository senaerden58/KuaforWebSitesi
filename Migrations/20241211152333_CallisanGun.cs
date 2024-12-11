using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class CallisanGun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalisanGun",
                columns: table => new
                {
                    CalisanGunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalisanID = table.Column<int>(type: "int", nullable: false),
                    GunID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalisanGun", x => x.CalisanGunID);
                    table.ForeignKey(
                        name: "FK_CalisanGun_Calisanlar_CalisanID",
                        column: x => x.CalisanID,
                        principalTable: "Calisanlar",
                        principalColumn: "CalisanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalisanGun_Gunler_GunID",
                        column: x => x.GunID,
                        principalTable: "Gunler",
                        principalColumn: "GunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalisanGun_CalisanID",
                table: "CalisanGun",
                column: "CalisanID");

            migrationBuilder.CreateIndex(
                name: "IX_CalisanGun_GunID",
                table: "CalisanGun",
                column: "GunID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalisanGun");
        }
    }
}
