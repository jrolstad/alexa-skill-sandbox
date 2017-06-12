using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstAlexaSkill.Application
{
    public class OutputSpeech
    {
        public string type { get; set; }
        public string text { get; set; }
    }

    public class Card
    {
        public string content { get; set; }
        public string title { get; set; }
        public string type { get; set; }
    }

    public class Response
    {
        public OutputSpeech outputSpeech { get; set; }
        public Card card { get; set; }
        public bool shouldEndSession { get; set; }
    }

    public class SessionAttributes
    {
    }

    public class AlexaServiceResponse
    {
        public static AlexaServiceResponse CreateOutputSpeechResponse(string intent, string outputSpeech)
        {
            var response = new AlexaServiceResponse
            {
                version = "1.1",
                sessionAttributes = new SessionAttributes(),
                response = new Response
                {
                    outputSpeech = new OutputSpeech
                    {
                        type = "PlainText",
                        text = outputSpeech
                    },
                    card = new Card
                    {
                        type = "Simple",
                        title = intent,
                        content = outputSpeech
                    },
                    shouldEndSession = true
                }
            };

            return response;
        }
        public string version { get; set; }
        public Response response { get; set; }
        public SessionAttributes sessionAttributes { get; set; }
    }
}
