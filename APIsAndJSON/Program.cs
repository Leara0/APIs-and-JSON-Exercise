namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            RonVSKanyeAPI.Conversation();
            Console.WriteLine("");
            
            OpenWeatherMapAPI.WeatherReport();

            Console.WriteLine("Thank you for using this app!");
        }
    }
}