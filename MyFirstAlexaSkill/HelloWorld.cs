using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
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

            var intentName = requestData?.request?.intent?.name;
            var outputSpeech = GetSpeechResponse(intentName);
            var response = AlexaServiceResponse.CreateOutputSpeechResponse(intentName, outputSpeech);

            return req.CreateResponse(HttpStatusCode.OK, response);
        }

        private static string GetSpeechResponse(string intent)
        {
            switch (intent)
            {
                case "FussyDaughterIntent":
                    return "It's because her name is Kenzie";
                case "LunaCrazyIntent":
                    return "Because she is a crazy puppy";
                case "LiamFeetIntent":
                    return "His feet are stinky because his name is stink foot";
                default:
                    return "I'm sorry I don't know how to do that";
            }
        }
    }
}