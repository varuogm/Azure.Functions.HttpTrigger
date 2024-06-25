using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureFucntionExample
{
    public static class AzureFunctionsExample
    {
        [FunctionName("SayBye")]
        public static IActionResult Byeer(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
        ILogger log)
        {
            const string name = "sexy sanskar";
            var responseMessage = $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new ObjectResult(responseMessage) { StatusCode = StatusCodes.Status200OK };
        }

        [FunctionName("GreetUser")]
        public static IActionResult Greeter(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

    }
}