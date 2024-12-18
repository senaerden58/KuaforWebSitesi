using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class AddMusteriRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusteriRol_Musteriler_MusteriID",
                table: "MusteriRol");

            migrationBuilder.DropForeignKey(
                name: "FK_MusteriRol_Rol_RolID",
                table: "MusteriRol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusteriRol",
                table: "MusteriRol");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Roller");

            migrationBuilder.RenameTable(
                name: "MusteriRol",
                newName: "MusteriRoller");

            migrationBuilder.RenameIndex(
                name: "IX_MusteriRol_RolID",
                table: "MusteriRoller",
                newName: "IX_MusteriRoller_RolID");

            migrationBuilder.RenameIndex(
                name: "IX_MusteriRol_MusteriID",
                table: "MusteriRoller",
                newName: "IX_MusteriRoller_MusteriID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roller",
                table: "Roller",
                column: "RolID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusteriRoller",
                table: "MusteriRoller",
                column: "MusteriRolID");

            migrationBuilder.AddForeignKey(
                name: "FK_MusteriRoller_Musteriler_MusteriID",
                table: "MusteriRoller",
                column: "MusteriID",
                principalTable: "Musteriler",
                principalColumn: "MusteriID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusteriRoller_Roller_RolID",
                table: "MusteriRoller",
                column: "RolID",
                principalTable: "Roller",
                principalColumn: "RolID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusteriRoller_Musteriler_MusteriID",
                table: "MusteriRoller");

            migrationBuilder.DropForeignKey(
                name: "FK_MusteriRoller_Roller_RolID",
                table: "MusteriRoller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roller",
                table: "Roller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusteriRoller",
                table: "MusteriRoller");

            migrationBuilder.RenameTable(
                name: "Roller",
                newName: "Rol");

            migrationBuilder.RenameTable(
                name: "MusteriRoller",
                newName: "MusteriRol");

            migrationBuilder.RenameIndex(
                name: "IX_MusteriRoller_RolID",
                table: "MusteriRol",
                newName: "IX_MusteriRol_RolID");

            migrationBuilder.RenameIndex(
                name: "IX_MusteriRoller_MusteriID",
                table: "MusteriRol",
                newName: "IX_MusteriRol_MusteriID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "RolID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusteriRol",
                table: "MusteriRol",
                column: "MusteriRolID");

            migrationBuilder.AddForeignKey(
                name: "FK_MusteriRol_Musteriler_MusteriID",
                table: "MusteriRol",
                column: "MusteriID",
                principalTable: "Musteriler",
                principalColumn: "MusteriID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusteriRol_Rol_RolID",
                table: "MusteriRol",
                column: "RolID",
                principalTable: "Rol",
                principalColumn: "RolID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
