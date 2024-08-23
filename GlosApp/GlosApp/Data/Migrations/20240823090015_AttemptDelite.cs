using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlosApp.Migrations
{
    /// <inheritdoc />
    public partial class AttemptDelite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordAnswers_Attempts_AttemptId",
                table: "WordAnswers");

            migrationBuilder.DropTable(
                name: "Attempts");

            migrationBuilder.DropIndex(
                name: "IX_WordAnswers_AttemptId",
                table: "WordAnswers");

            migrationBuilder.DropColumn(
                name: "AttemptId",
                table: "WordAnswers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttemptId",
                table: "WordAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Attempts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttemptDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attempts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordAnswers_AttemptId",
                table: "WordAnswers",
                column: "AttemptId");

            migrationBuilder.AddForeignKey(
                name: "FK_WordAnswers_Attempts_AttemptId",
                table: "WordAnswers",
                column: "AttemptId",
                principalTable: "Attempts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
