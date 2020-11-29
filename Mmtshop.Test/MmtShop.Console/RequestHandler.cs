using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MmtShop.Console
{
    public class RequestHandler
    {
        private readonly ILogger<RequestHandler> _logger;
        private IHttpClientFactory _httpFactory { get; set; }
        public RequestHandler(ILogger<RequestHandler> logger, 
        IHttpClientFactory httpFactory)
        {
            _logger = logger;
            _httpFactory = httpFactory;
        }

        public async Task<string> Run(string apiUrl)
        {
            _logger.LogInformation("Application {applicationEvent} at {dateTime}", "Started", DateTime.UtcNow);

            HttpClient client = GetClient();
            var response = await client.SendAsync(GetRequest(apiUrl));

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Application {applicationEvent} at {dateTime}", "Complete", DateTime.UtcNow);
                return await response.Content.ReadAsStringAsync();

            }
            else
            {
                return $"StatusCode: {response.ReasonPhrase}";
            }
        }

        private static HttpRequestMessage GetRequest(string apiUrl)
        {
            return new HttpRequestMessage(HttpMethod.Get, apiUrl);
        }

        private HttpClient GetClient()
        {
            var client = _httpFactory.CreateClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
 }

