namespace GlosApp.Models;

public class QuizQuestion
{
    public string QuestionText { get; set; } = null!;
    public List<QuizOption>? Options { get; set; } 
    public string CorrectAnswer { get; set; } = null!;
}

public class QuizOption
{
    public string OptionText { get; set; } = null!;
}