namespace GlosApp.Models;

public class WordAnswer
{
    public int Id { get; set; } 
    public string Swedish { get; set; } = null!;
    public string English { get; set; } = null!;
    public string UserAnswer { get; set; } = null!;
    public string Language { get; set; } = null!;
    public DateTime Timestamp { get; set; } 

    // Standardkonstruktor
    public WordAnswer()
    {
        Timestamp = DateTime.Now;
    }

    public WordAnswer(string swedish, string english, string language = null!)
    {
        Swedish = swedish;
        English = english;
        Language = language;
        Timestamp = DateTime.Now;
    }
}

