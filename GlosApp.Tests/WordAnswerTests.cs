using GlosApp.Models;
using System;
using Xunit;

public class WordAnswerTests
{
    [Fact]
    public void DefaultConstructor_ShouldSetTimestamp()
    {
        // Arrange
        var wordAnswer = new WordAnswer();

        // Act
        var timestamp = wordAnswer.Timestamp;

        // Assert
        Assert.True((DateTime.Now - timestamp).TotalSeconds < 1);
    }

    [Fact]
    public void ParametrizedConstructor_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        var swedish = "garderob";
        var english = "closet";
        var language = "sv";

        // Act
        var wordAnswer = new WordAnswer(swedish, english, language);

        // Assert
        Assert.Equal(swedish, wordAnswer.Swedish);
        Assert.Equal(english, wordAnswer.English);
        Assert.Equal(language, wordAnswer.Language);
        Assert.True((DateTime.Now - wordAnswer.Timestamp).TotalSeconds < 1);
    }

    [Fact]
    public void SetUserAnswer_ShouldUpdateCorrectly()
    {
        // Arrange
        var wordAnswer = new WordAnswer();
        var userAnswer = "closet";

        // Act
        wordAnswer.UserAnswer = userAnswer;

        // Assert
        Assert.Equal(userAnswer, wordAnswer.UserAnswer);
    }
}
