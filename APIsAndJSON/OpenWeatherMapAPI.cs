﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        public static string RetrieveTempString(string zipCode)
        {
            var keyText = File.ReadAllText("appsettings.json");
            var key = JObject.Parse(keyText)["key"].ToString();
            var weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&appid={key}&units=imperial";

            var weatherResponseJson = GetClient.Client.GetStringAsync(weatherUrl).Result;
            return weatherResponseJson;

        }

        public static int CurrentTemp(string zipCode)
        {
            var WeatherResponseJson = RetrieveTempString(zipCode);
            var currentTemp = JObject.Parse(WeatherResponseJson)["main"]["temp"].ToString();
            var doubleTemp = double.Parse(currentTemp);
            int temp = Convert.ToInt32(doubleTemp);
            return temp;
        }

        public static int FeelsLikeTemp(string zipCode)
        {
            var WeatherResponseJson = RetrieveTempString(zipCode);
            var feelsLikeTemp = JObject.Parse(WeatherResponseJson)["main"]["feels_like"].ToString();
            var doubleTemp = double.Parse(feelsLikeTemp);
            int temp = Convert.ToInt32(doubleTemp);
            return temp;
        }

        public static void WeatherReport()
        {
            bool continueLoop = true;
            while (continueLoop)
            {
                string zipCode = UserInteraction.GetZipCode();
                Console.WriteLine(
                    $"The current temperature in {ZipToCityAPI.ConvertZipCodeToCity(zipCode)} is {CurrentTemp(zipCode)}\u00b0 F");
                Console.WriteLine($"It feels like {FeelsLikeTemp(zipCode)}\u00b0 F");
                if (!UserInteraction.Continue())
                    continueLoop = false;
            }
        }
    }
}
