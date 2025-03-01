using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlosApp.Migrations
{
    /// <inheritdoc />
    public partial class Survey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsageFrequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VocabularyExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsesExplanationButton = table.Column<bool>(type: "bit", nullable: false),
                    AiQuizExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AiTeacherFeedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AiWritingImprovement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BestFeature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuggestedImprovements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecommendWebsite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResponses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyResponses");
        }
    }
}
