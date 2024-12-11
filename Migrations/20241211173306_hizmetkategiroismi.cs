using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class hizmetkategiroismi : Migration
    {
        /// <inheritdoc />
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.AddColumn<int>(
                    name: "HizmetKategoriID",
                    table: "Hizmetler",
                    nullable: false); // veya false olarak belirleyebilirsiniz
            }

            protected override void Down(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.DropColumn(
                    name: "HizmetKategoriID",
                    table: "Hizmetler");
            }
        }

    
}
