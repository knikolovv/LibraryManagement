using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Data.Migrations
{
    public partial class readerUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MostRecentTakenBookId",
                table: "Readers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Books",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Readers_MostRecentTakenBookId",
                table: "Readers",
                column: "MostRecentTakenBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Books_MostRecentTakenBookId",
                table: "Readers",
                column: "MostRecentTakenBookId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Books_MostRecentTakenBookId",
                table: "Readers");

            migrationBuilder.DropIndex(
                name: "IX_Readers_MostRecentTakenBookId",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "MostRecentTakenBookId",
                table: "Readers");

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
