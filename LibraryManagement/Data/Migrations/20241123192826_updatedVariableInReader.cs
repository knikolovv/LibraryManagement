using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Data.Migrations
{
    public partial class updatedVariableInReader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BooksBorrowed",
                table: "Readers",
                newName: "NumberOfBoughtBooks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfBoughtBooks",
                table: "Readers",
                newName: "BooksBorrowed");
        }
    }
}
