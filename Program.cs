using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {


            List<string> mods = new List<string>();
            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path, "*.dat", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string[] lines = File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    if (line.Contains("\\"))
                        mods.Add(file);
                }
            }
            File.WriteAllLines("mods.txt", mods);
        }


        public class Event
        {
            public string name { get; set; }
            public string description { get; set; }
            public string entity_type { get; set; }
            public string privacy_level { get; set; }
            public string scheduled_start_time { get; set; }
            public string scheduled_end_time { get; set; }
            public entity_metadata entity_metadata { get; set; }

        }

        public class entity_metadata
        {
            public string location { get; set; }
        }

        static void sendDiscordWebhook(string URL, string threadId, string username, string message)
        {
            NameValueCollection discordValues = new NameValueCollection();
            discordValues.Add("username", username);
            discordValues.Add("content", message);
            discordValues.Add("thread_id", threadId);
            new WebClient().UploadValues(URL, discordValues);
        }

        
    }

    public class Id
    {
        public long id { get; set; }
    }
}
