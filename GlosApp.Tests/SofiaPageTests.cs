//using Microsoft.EntityFrameworkCore;
//using Moq;
//using Xunit;
//using GlosApp.Components.Pages;
//using GlosApp.Models;
//using GlosApp.Data;
//using static GlosApp.Components.Pages.Sofia;
//using Bunit;

//public class SofiaPageTests : TestContext
//{
//    [Fact]
//    public void CheckAnswers_ShouldCalculateCorrectAnswers()
//    {
//        // Arrange
//        var mockDbContext = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
//        var component = RenderComponent<Sofia>(parameters => parameters.Add(p => p.MyDbContext, mockDbContext.Object));

//        var userAnswerForm = component.Instance.GetType().GetProperty("userAnswerForm").GetValue(component.Instance) as UserAnswerForm;

//        // Set user answers
//        userAnswerForm.Answers[0].UserAnswer = "sure"; // correct answer
//        userAnswerForm.Answers[1].UserAnswer = "penguins"; // correct answer
//        userAnswerForm.Answers[2].UserAnswer = "wrong answer"; // incorrect answer

//        // Act
//        component.Instance.CheckAnswers();

//        // Assert
//        Assert.Equal(2, component.Instance.correctAnswers); // Should be 2 correct
//        Assert.False(component.Instance.missingAnswers); // No fields should be empty
//        Assert.True(component.Instance.showResult); // Result should be shown
//    }

//    [Fact]
//    public void CheckAnswers_ShouldNotShowResultIfFieldIsEmpty()
//    {
//        // Arrange
//        var mockDbContext = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
//        var component = RenderComponent<Sofia>(parameters => parameters.Add(p => p.MyDbContext, mockDbContext.Object));

//        var userAnswerForm = component.Instance.GetType().GetProperty("userAnswerForm").GetValue(component.Instance) as UserAnswerForm;

//        // Leave one field empty
//        userAnswerForm.Answers[0].UserAnswer = "sure"; // correct answer
//        userAnswerForm.Answers[1].UserAnswer = ""; // empty field

//        // Act
//        component.Instance.CheckAnswers();

//        // Assert
//        Assert.Equal(0, component.Instance.correctAnswers); // No correct
//        Assert.True(component.Instance.missingAnswers); // Should be empty
//        Assert.False(component.Instance.showResult); // Result should not be shown
//    }

//    [Fact]
//    public void ResetForm_ShouldClearAllUserAnswers()
//    {
//        // Arrange
//        var mockDbContext = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
//        var component = RenderComponent<Sofia>(parameters => parameters.Add(p => p.MyDbContext, mockDbContext.Object));

//        var userAnswerForm = component.Instance.GetType().GetProperty("userAnswerForm").GetValue(component.Instance) as UserAnswerForm;

//        // Set user answers
//        userAnswerForm.Answers[0].UserAnswer = "some answer";

//        // Act
//        component.Instance.ResetForm();

//        // Assert
//        Assert.All(userAnswerForm.Answers, answer => Assert.Empty(answer.UserAnswer)); // Should be empty
//        Assert.Equal(0, component.Instance.correctAnswers); // Should be 0
//        Assert.False(component.Instance.showResult); // Should be false
//        Assert.False(component.Instance.missingAnswers); // Should be false
//    }
//}