using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Runtime.ConstrainedExecution;

namespace APIsault.Azure.Servers.Functions {
    public class AllFunctions {
        private readonly ILogger _logger;
        public AllFunctions(ILoggerFactory loggerFactory) {
            _logger = loggerFactory.CreateLogger<AllFunctions>();
        }

        private static Random random = new Random();
        private object MakePerson() {
            return new {
                id = Guid.NewGuid().ToString(),
                name = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 20).Select(s => s[random.Next(s.Length)]).ToArray())
            };
        }
  

        [Function("SimpleJson")]
        public HttpResponseData SimpleJson([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req) {
            _logger.LogInformation("Entered the SimpleJson API");
            string jsonToReturn = JsonConvert.SerializeObject(MakePerson());
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");
            response.WriteString(jsonToReturn);
            _logger.LogInformation("Leaving the SimpleJson API");

            return response;
        }

        [Function("JustWait")]
        public async Task<HttpResponseData> JustWait([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req) {
            _logger.LogInformation("Entered the JustWait API");
            var query = System.Web.HttpUtility.ParseQueryString(req.Url.Query);

            HttpResponseData responseData;

            int waitMS = 0;
            if (query.Count != 0 && query["waitMS"] != null && int.TryParse(query["waitMS"], out waitMS)) {
                _logger.LogInformation("Now waiting...");
                await Task.Delay(waitMS);
                _logger.LogInformation("Wait is over!");

                string jsonToReturn = JsonConvert.SerializeObject(MakePerson());

                responseData = req.CreateResponse(HttpStatusCode.OK);
                responseData.Headers.Add("Content-Type", "application/json; charset=utf-8");
                responseData.WriteString(jsonToReturn);

                _logger.LogInformation("Leaving the JustWait API");
                return responseData;
            }
            else {
                responseData = req.CreateResponse(HttpStatusCode.BadRequest);
                responseData.WriteString("waitMS query parameter is incorrect");
                return responseData;
            }
        }


        [Function("JustWaitWithoutAsync")]
        public HttpResponseData JustWaitWithoutAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req) {
            _logger.LogInformation("Entered the JustWaitWithoutAsync API");
            var query = System.Web.HttpUtility.ParseQueryString(req.Url.Query);

            HttpResponseData responseData;

            int waitMS = 0;
            if (query.Count != 0 && query["waitMS"] != null && int.TryParse(query["waitMS"], out waitMS)) {
                _logger.LogInformation("Now waiting...");
                Task.Delay(waitMS);
                _logger.LogInformation("Wait is over!");

                string jsonToReturn = JsonConvert.SerializeObject(MakePerson());

                responseData = req.CreateResponse(HttpStatusCode.OK);
                responseData.Headers.Add("Content-Type", "application/json; charset=utf-8");
                responseData.WriteString(jsonToReturn);

                _logger.LogInformation("Leaving the JustWaitWithoutAsync API");
                return responseData;
            }
            else {
                responseData = req.CreateResponse(HttpStatusCode.BadRequest);
                responseData.WriteString("waitMS query parameter is incorrect");
                return responseData;
            }
        }
    }
}
