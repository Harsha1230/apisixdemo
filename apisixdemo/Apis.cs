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
        public HttpResponseData GetWeather([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "apisixdemo/getweather")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions! route is apisixdemo/getweather");

            return response;
        }

        [Function("GetAnotherWeather")]
        public HttpResponseData GetAnotherWeather([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "apisixdemo/getweather/param")] HttpRequestData req, string test)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString($"Welcome to Azure Functions! {test} route is apisixdemo/getweather/param");

            return response;
        }

        [Function("GetWeatherWithPathParams")]
        public HttpResponseData GetWeatherWithPathParams([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "apisixdemo/getweather/{id}")] HttpRequestData req, int id)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString($"Welcome to Azure Functions! {id} route is apisixdemo/getweather/id");

            return response;
        }

        [Function("GetWeatherWithMultiParam")]
        public HttpResponseData GetWeatherWithMultiParam([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "apisixdemo/getweather/getweatherwithmultiparam")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions! route is apisixdemo/getweather/getweatherwithmultiparam");

            return response;
        }
    }
}
