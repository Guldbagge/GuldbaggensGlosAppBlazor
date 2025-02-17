namespace GlosApp.Models;

public class QuizQuestionModel
{
    public string QuestionText { get; set; } = "";
    public List<string> Options { get; set; } = new();
    public string CorrectAnswer { get; set; } = "";
    public string? SelectedAnswer { get; set; }
    public bool ShowCorrectAnswer { get; set; } = false; 
}



