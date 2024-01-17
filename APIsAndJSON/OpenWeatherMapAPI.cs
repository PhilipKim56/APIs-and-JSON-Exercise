using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        public static void GetTemp()
        {
            var appsettingsText = File.ReadAllText("appsettings.json");

            var apiKey = JObject.Parse(appsettingsText).GetValue("apiKey").ToString();

            Console.WriteLine("Please enter in your 5 digit ZIP code: ");

            var zip = Console.ReadLine();

            var url = $"https://api.openweathermap.org/data/2.5/weather?zip={zip}&appid={apiKey}&units=imperial";

            var client = new HttpClient();

            var response = client.GetStringAsync(url).Result;

            var weatherObject = JObject.Parse(response);

            Console.WriteLine($"The temperature in {weatherObject["name"]} is  {weatherObject["main"]["temp"]} degrees Fahrenheit");

            

        }
    }
}
