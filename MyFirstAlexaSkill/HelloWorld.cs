using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System;
using MyFirstAlexaSkill.Application;

namespace MyFirstAlexaSkill
{
    public static class HelloWorld
    {
        [FunctionName("AlexaHelloWorld")]

        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "AlexaHelloWorld")]
            HttpRequestMessage req, 
            TraceWriter log)
        {

            var requestData = req.Content.ReadAsAsync<AlexaServiceRequest>().Result;

            if(requestData?.request?.intent?.name == "FussyDaughterIntent")
            {
                var response = AlexaServiceResponse.CreateOutputSpeechResponse(requestData?.request?.intent?.name, "It's because her name is Kenzie");
                return req.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                var response = AlexaServiceResponse.CreateOutputSpeechResponse(requestData?.request?.intent?.name, "Hello World");
                return req.CreateResponse(HttpStatusCode.OK, response);
            }
           
        }
    }
}