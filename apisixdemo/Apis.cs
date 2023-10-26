using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace apisixdemo
{
    public class Apis
    {
        private readonly ILogger _logger;

        public Apis(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Apis>();
        }

        [Function("GetWeather")]
        public HttpResponseData GetWeather([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "ApisixDemo/GetWeather")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
