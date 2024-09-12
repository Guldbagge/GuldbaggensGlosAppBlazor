namespace GlosApp.Models;

public class QuizQuestion
{
    public string QuestionText { get; set; }
    public List<QuizOption> Options { get; set; }
    public string CorrectAnswer { get; set; }
}

public class QuizOption
{
    public string OptionText { get; set; }
}