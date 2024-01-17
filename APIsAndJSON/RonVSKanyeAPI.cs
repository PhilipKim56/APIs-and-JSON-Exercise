using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class RonVSKanyeAPI
    {
        private static string KanyeQ(HttpClient client)
        {
            var jText = client.GetStringAsync("https://api.kanye.rest/").Result;
            var quote = JObject.Parse(jText).GetValue("quote").ToString();
            return quote;
        }

        private static string RonQ(HttpClient client)
        {
            var jText = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
            var quote = JArray.Parse(jText).ToString().Replace('[',' ').Replace(']',' ').Replace('"', ' ').Trim();
            return quote;
        }

        public static void Conversation()
        {
            var client = new HttpClient();

            for(int i = 0; i < 5; i++) 
            {
                Console.WriteLine($"Kanye:{KanyeQ(client)}\n");
                Console.WriteLine($"Ron:{RonQ(client)}\n");

            }
        }
    }
}
