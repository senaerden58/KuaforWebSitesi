using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class AddCalisanResimYolu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResimYolu",
                table: "Calisanlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResimYolu",
                table: "Calisanlar");
        }
    }
}
