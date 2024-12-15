using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforWebSitesi.Migrations
{
    /// <inheritdoc />
    public partial class AddBaslangicBitis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "BaslangicSaati",
                table: "CalisanGunler",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "BitisSaati",
                table: "CalisanGunler",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 1, 5 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 2, 5 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 2, 6 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 3, 1 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 3, 5 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 3, 6 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 4, 1 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 4, 2 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 4, 5 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 4, 6 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 5, 1 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 5, 5 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 5, 7 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 6, 2 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 6, 3 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 6, 5 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 6, 6 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 6, 7 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 7, 1 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 7, 3 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 7, 4 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "CalisanGunler",
                keyColumns: new[] { "CalisanID", "GunID" },
                keyValues: new object[] { 7, 7 },
                columns: new[] { "BaslangicSaati", "BitisSaati" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaslangicSaati",
                table: "CalisanGunler");

            migrationBuilder.DropColumn(
                name: "BitisSaati",
                table: "CalisanGunler");
        }
    }
}
