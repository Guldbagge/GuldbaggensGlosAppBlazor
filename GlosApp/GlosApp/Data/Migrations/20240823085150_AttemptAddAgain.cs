using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlosApp.Migrations
{
    /// <inheritdoc />
    public partial class AttemptAddAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SofiaWordAnswers_SofiaAttempts_AttemptId",
                table: "SofiaWordAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SofiaWordAnswers",
                table: "SofiaWordAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SofiaAttempts",
                table: "SofiaAttempts");

            migrationBuilder.RenameTable(
                name: "SofiaWordAnswers",
                newName: "WordAnswers");

            migrationBuilder.RenameTable(
                name: "SofiaAttempts",
                newName: "Attempts");

            migrationBuilder.RenameIndex(
                name: "IX_SofiaWordAnswers_AttemptId",
                table: "WordAnswers",
                newName: "IX_WordAnswers_AttemptId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordAnswers",
                table: "WordAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attempts",
                table: "Attempts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WordAnswers_Attempts_AttemptId",
                table: "WordAnswers",
                column: "AttemptId",
                principalTable: "Attempts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordAnswers_Attempts_AttemptId",
                table: "WordAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordAnswers",
                table: "WordAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attempts",
                table: "Attempts");

            migrationBuilder.RenameTable(
                name: "WordAnswers",
                newName: "SofiaWordAnswers");

            migrationBuilder.RenameTable(
                name: "Attempts",
                newName: "SofiaAttempts");

            migrationBuilder.RenameIndex(
                name: "IX_WordAnswers_AttemptId",
                table: "SofiaWordAnswers",
                newName: "IX_SofiaWordAnswers_AttemptId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SofiaWordAnswers",
                table: "SofiaWordAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SofiaAttempts",
                table: "SofiaAttempts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SofiaWordAnswers_SofiaAttempts_AttemptId",
                table: "SofiaWordAnswers",
                column: "AttemptId",
                principalTable: "SofiaAttempts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
