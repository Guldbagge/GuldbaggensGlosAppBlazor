using System.Collections.Generic;
using Xunit;
using GlosApp.Models;

public class QuizQuestionTests
{
    [Fact]
    public void QuizQuestion_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        var questionText = "What is the capital of Sweden?";
        var correctAnswer = "Stockholm";
        var options = new List<QuizOption>
        {
            new QuizOption { OptionText = "Stockholm" },
            new QuizOption { OptionText = "Gothenburg" },
            new QuizOption { OptionText = "Malmö" }
        };

        // Act
        var quizQuestion = new QuizQuestion
        {
            QuestionText = questionText,
            CorrectAnswer = correctAnswer,
            Options = options
        };

        // Assert
        Assert.Equal(questionText, quizQuestion.QuestionText);
        Assert.Equal(correctAnswer, quizQuestion.CorrectAnswer);
        Assert.Equal(3, quizQuestion.Options?.Count); 
        Assert.Contains(quizQuestion.Options, o => o.OptionText == "Stockholm");
    }

    [Fact]
    public void QuizOption_ShouldSetOptionTextCorrectly()
    {
        // Arrange
        var optionText = "Stockholm";

        // Act
        var quizOption = new QuizOption { OptionText = optionText };

        // Assert
        Assert.Equal(optionText, quizOption.OptionText);
    }
}
