using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace TelemetryTestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuccessController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        HttpClient client = new HttpClient();

        client.BaseAddress = new Uri("http://172.24.10.159:4318");

        HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "v1/traces");
        HttpRequestOptions options = new HttpRequestOptions();
        //message.Options = 
        message.Content = new StringContent("{\r\n  \"resourceSpans\": [\r\n    {\r\n      \"resource\": {\r\n        \"attributes\": [\r\n          { \"key\": \"service.name\", \"value\": { \"stringValue\": \"postman-prism-test\" } }\r\n        ]\r\n      },\r\n      \"scopeSpans\": [\r\n        {\r\n          \"scope\": { \"name\": \"postman-scope\", \"version\": \"1.0.0\" },\r\n          \"spans\": [\r\n            {\r\n              \"traceId\": \"4bf92f3577b34db6a3ce929d0e0e4736\",\r\n              \"spanId\": \"00f067aa0ba902c7\",\r\n              \"name\": \"manual-postman-span\",\r\n              \"kind\": 1,\r\n              \"attributes\": [\r\n                { \"key\": \"http.method\", \"value\": { \"stringValue\": \"GET\" } },\r\n                { \"key\": \"http.route\", \"value\": { \"stringValue\": \"/from-postman\" } },\r\n                { \"key\": \"http.status_code\", \"value\": { \"intValue\": 200 } }\r\n              ]\r\n            }\r\n          ]\r\n        }\r\n      ]\r\n    }\r\n  ]\r\n}", Encoding.UTF8, "application/json");
        var results = client.SendAsync(message).Result;



        return Ok(new { success = true });
    }
}
