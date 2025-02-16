namespace GlosApp.Models;

public class QuizQuestionModel
{
    public string QuestionText { get; set; } = string.Empty;
    public List<string> Options { get; set; } = new();
    public string CorrectAnswer { get; set; } = string.Empty;

    public string SelectedAnswer { get; set; } = string.Empty;
}



