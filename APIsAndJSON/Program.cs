namespace APIsAndJSON
{
    public class Program
    {
        public static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            
            var convoCounter = 0;
            var random = new Random();
            var convoLength = random.Next(6, 10);

            while (convoCounter < convoLength)
            {
                Console.WriteLine($"Kanye: {RonVSKanyeAPI.KanyeQuote()}");
                Thread.Sleep(1000);
                Console.WriteLine($"Ron: {RonVSKanyeAPI.RonQuote()}");
                Thread.Sleep(1000);
                convoCounter++;
            }

            Console.WriteLine("");
            bool continueLoop = true;
            while (continueLoop)
            {
                string zipCode = UserInteraction.GetZipCode();
                Console.WriteLine(
                    $"The current temperature in this area is {OpenWeatherMapAPI.CurrentTemp(zipCode)}\u00b0 F");
                Console.WriteLine($"It feels like {OpenWeatherMapAPI.FeelsLikeTemp(zipCode)}\u00b0 F");
                if (!UserInteraction.Continue())
                    continueLoop = false;
            }

            Console.WriteLine("Thank you for using this app!");
        }
    }
}