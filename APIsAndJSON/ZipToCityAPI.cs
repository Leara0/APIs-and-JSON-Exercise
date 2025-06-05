using Newtonsoft.Json.Linq;

namespace APIsAndJSON;

public class ZipToCityAPI
{
    public static string ConvertZipCodeToCity(string zipCode)
    {
        var url = $"https://api.zippopotam.us/us/{zipCode}";
        var cityResponseJson = GetClient.Client.GetStringAsync(url).Result;
        var city= JObject.Parse(cityResponseJson)["places"][0]["place name"].ToString();
        var state = JObject.Parse(cityResponseJson)["places"][0]["state"].ToString();
        return city + ", " + state;
    }
}