using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class RonVSKanyeAPI
    {
        public static string KanyeQuote()
        {
            var client = new HttpClient();
            var kanyeUrl = "https://api.kanye.rest/";
            var kanyeResponseJson = client.GetStringAsync(kanyeUrl).Result;
            var kanyeQuote = JObject.Parse(kanyeResponseJson)["quote"].ToString();
            return kanyeQuote;
        }

        public static string RonQuote()
        {
            var client = new HttpClient();
            var ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponseJson = client.GetStringAsync(ronUrl).Result;
            var ronQuote = ronResponseJson.Substring(2, ronResponseJson.Length - 4);
            return ronQuote;
        }
    }
}