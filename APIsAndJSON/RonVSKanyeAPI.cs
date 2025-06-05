using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal static class RonVSKanyeAPI
    {
        public static string KanyeQuote()
        {
            var kanyeUrl = "https://api.kanye.rest/";
            var kanyeResponseJson = GetClient.Client.GetStringAsync(kanyeUrl).Result;
            return JObject.Parse(kanyeResponseJson)["quote"].ToString();
        }

        public static string RonQuote()
        {
            var ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponseJson = GetClient.Client.GetStringAsync(ronUrl).Result;
            return ronResponseJson.Substring(2, ronResponseJson.Length - 4);
        }

        
        public static void Conversation()
        {
            var random = new Random();
            var convoLength = random.Next(6, 10);

            for (int i = 0; i < convoLength; i++)
            {
                Console.WriteLine($"Kanye: {KanyeQuote()}");
                Thread.Sleep(2000);
                Console.WriteLine($"Ron: {RonQuote()}");
                Thread.Sleep(2000);
            }
        }
    }
}