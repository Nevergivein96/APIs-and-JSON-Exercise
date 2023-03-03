using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace APIsAndJSON
{
    public class QuoteGenerator
    {
        public static void KanyeQuote()
        {
            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest";
            var kayneResponse = client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kayneResponse).GetValue("quote").ToString();
            Console.WriteLine("---------------------");
            Console.WriteLine($"Kanye: '{kanyeQuote}'");
            Console.WriteLine("---------------------");
        }
        public static void RonQuotes()
        {
            var client = new HttpClient();
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronget = client.GetStringAsync(ronURL).Result;
            var ronQuote = JArray.Parse(ronget).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            Console.WriteLine("---------------------");
            Console.WriteLine($"Ron: '{ronQuote}'");
            Console.WriteLine("---------------------");
        }
    }
}
