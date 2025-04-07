using GlosApp.Data;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using System.Net;
using System.Text.Json;
using GlosApp.Models;
using Microsoft.Extensions.Logging;

public class SaveWordAnswersFunction
{
    private readonly ApplicationDbContext _context;

    public SaveWordAnswersFunction(ApplicationDbContext context)
    {
        _context = context;
    }

    [Function("SaveWordAnswers")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("SaveWordAnswers");

        var requestBody = await req.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(requestBody))
        {
            var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await badResponse.WriteStringAsync("Request body is empty.");
            return badResponse;
        }

        List<WordAnswer>? answers;

        try
        {
            answers = JsonSerializer.Deserialize<List<WordAnswer>>(requestBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        catch (JsonException)
        {
            var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await badResponse.WriteStringAsync("Invalid JSON format.");
            return badResponse;
        }

        if (answers == null || !answers.Any())
        {
            var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await badResponse.WriteStringAsync("No word answers provided.");
            return badResponse;
        }

        try
        {
            foreach (var answer in answers)
            {
                answer.Timestamp = DateTime.UtcNow.AddHours(2);
                _context.WordAnswers.Add(answer);
            }

            await _context.SaveChangesAsync();

            logger.LogInformation($"Successfully saved {answers.Count} word answers.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error saving word answers.");
            var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
            await errorResponse.WriteStringAsync($"Error saving answers: {ex.Message}");
            return errorResponse;
        }

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteStringAsync("Answers saved!");
        return response;
    }
}
