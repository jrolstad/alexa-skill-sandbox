using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstAlexaSkill.Application
{
    public class Application
    {
        public string applicationId { get; set; }
    }

    public class Attributes
    {
    }

    public class User
    {
        public string userId { get; set; }
    }

    public class Session
    {
        public string sessionId { get; set; }
        public Application application { get; set; }
        public Attributes attributes { get; set; }
        public User user { get; set; }
        public bool @new { get; set; }
    }

    public class Slots
    {
    }

    public class Intent
    {
        public string name { get; set; }
        public Slots slots { get; set; }
    }

    public class Request
    {
        public string type { get; set; }
        public string requestId { get; set; }
        public string locale { get; set; }
        public string timestamp { get; set; }
        public Intent intent { get; set; }
    }

    public class AlexaServiceRequest
    {
        public Session session { get; set; }
        public Request request { get; set; }
        public string version { get; set; }
    }
}
