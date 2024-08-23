using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlosApp.Migrations
{
    /// <inheritdoc />
    public partial class AttemptIsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WordAnswers",
                table: "WordAnswers");

            migrationBuilder.RenameTable(
                name: "WordAnswers",
                newName: "SofiaWordAnswers");

            migrationBuilder.AddColumn<int>(
                name: "AttemptId",
                table: "SofiaWordAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SofiaWordAnswers",
                table: "SofiaWordAnswers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SofiaAttempts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttemptDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SofiaAttempts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SofiaWordAnswers_AttemptId",
                table: "SofiaWordAnswers",
                column: "AttemptId");

            migrationBuilder.AddForeignKey(
                name: "FK_SofiaWordAnswers_SofiaAttempts_AttemptId",
                table: "SofiaWordAnswers",
                column: "AttemptId",
                principalTable: "SofiaAttempts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SofiaWordAnswers_SofiaAttempts_AttemptId",
                table: "SofiaWordAnswers");

            migrationBuilder.DropTable(
                name: "SofiaAttempts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SofiaWordAnswers",
                table: "SofiaWordAnswers");

            migrationBuilder.DropIndex(
                name: "IX_SofiaWordAnswers_AttemptId",
                table: "SofiaWordAnswers");

            migrationBuilder.DropColumn(
                name: "AttemptId",
                table: "SofiaWordAnswers");

            migrationBuilder.RenameTable(
                name: "SofiaWordAnswers",
                newName: "WordAnswers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordAnswers",
                table: "WordAnswers",
                column: "Id");
        }
    }
}
