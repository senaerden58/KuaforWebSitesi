using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class AddCalisanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calisanlar",
                columns: table => new
                {
                    CalisanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalisanAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalisanSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalisanMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalisanTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalisanSifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisanlar", x => x.CalisanID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calisanlar");
        }
    }
}
