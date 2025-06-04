namespace APIsAndJSON;

public class UserInteraction
{
    public static string GetZipCode()
    {
        bool validZipCode = false;
        string zipCode ="";

        while (!validZipCode)
        {
            Console.WriteLine("Please enter a valid zip code");
            zipCode = Console.ReadLine();
            if (int.TryParse(zipCode, out int intZipCode))
            {
                if (intZipCode > 9999 && intZipCode < 100000)
                    validZipCode = true;
            }
        }

        return zipCode;
    }

    public static bool Continue()
    {
        while (true)
        {
            Console.WriteLine("Would you like to continue? y/n");
            var input = Console.ReadLine();
            if (input.ToLower() == "y")
                return true;
            if (input.ToLower() == "n")
                return false;
        }
    }
    
}