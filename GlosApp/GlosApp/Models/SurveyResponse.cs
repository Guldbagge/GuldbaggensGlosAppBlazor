namespace GlosApp.Models;

public class SurveyResponse
{
    public int Id { get; set; }
    public string UsageFrequency { get; set; } = string.Empty;
    public string VocabularyExperience { get; set; } = string.Empty;
    public bool UsesExplanationButton { get; set; }
    public string AiQuizExperience { get; set; } = string.Empty;
    public string AiTeacherFeedback { get; set; } = string.Empty;
    public string AiWritingImprovement { get; set; } = string.Empty;
    public string BestFeature { get; set; } = string.Empty;
    public string SuggestedImprovements { get; set; } = string.Empty;
    public string RecommendWebsite { get; set; } = string.Empty;
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
}


