using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlosApp.Migrations
{
    public partial class UpdateWordAnswerModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Lägg endast till den nya tabellen
            migrationBuilder.CreateTable(
                name: "TranslatedWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Swedish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    English = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslatedWords", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Ta bort tabellen om migrationen rullas tillbaka
            migrationBuilder.DropTable(
                name: "TranslatedWords");
        }
    }
}
