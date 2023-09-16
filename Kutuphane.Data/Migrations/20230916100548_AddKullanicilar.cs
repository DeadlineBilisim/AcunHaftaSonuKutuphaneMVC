using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kutuphane.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddKullanicilar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "Yazarlar",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "YayinEvleri",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "Kitaplar",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Yazarlar_KullaniciId",
                table: "Yazarlar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_YayinEvleri_KullaniciId",
                table: "YayinEvleri",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_KullaniciId",
                table: "Kitaplar",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaplar_Kullanicilar_KullaniciId",
                table: "Kitaplar",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_YayinEvleri_Kullanicilar_KullaniciId",
                table: "YayinEvleri",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Yazarlar_Kullanicilar_KullaniciId",
                table: "Yazarlar",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitaplar_Kullanicilar_KullaniciId",
                table: "Kitaplar");

            migrationBuilder.DropForeignKey(
                name: "FK_YayinEvleri_Kullanicilar_KullaniciId",
                table: "YayinEvleri");

            migrationBuilder.DropForeignKey(
                name: "FK_Yazarlar_Kullanicilar_KullaniciId",
                table: "Yazarlar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropIndex(
                name: "IX_Yazarlar_KullaniciId",
                table: "Yazarlar");

            migrationBuilder.DropIndex(
                name: "IX_YayinEvleri_KullaniciId",
                table: "YayinEvleri");

            migrationBuilder.DropIndex(
                name: "IX_Kitaplar_KullaniciId",
                table: "Kitaplar");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Yazarlar");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "YayinEvleri");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Kitaplar");
        }
    }
}
