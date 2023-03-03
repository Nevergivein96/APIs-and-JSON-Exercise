using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        public static void WeatherApp()
        {
            var client = new HttpClient();
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter City name");
                var city_name = Console.ReadLine();
                try
                {
                    var waeatherAppURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid=e6ffb2e525fc0e7444ca03d393138f5d";
                    var response = client.GetStringAsync(waeatherAppURL).Result;
                    var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                    Console.WriteLine($"The current temperature in {city_name} is {JObject.Parse(formattedResponse).GetValue("temp")}");
                }
                catch(Exception e)  
                {
                    Console.WriteLine(e.Message);
                }             
                Console.WriteLine();
                Console.WriteLine("Would you like to exit?");
                var input = Console.ReadLine();
                Console.WriteLine();
                if(input.ToLower().Trim() == "yes")
                {
                    break;
                }
            }
        }
    }
}
