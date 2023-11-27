using Net14OnlineConsole.Models;

namespace Net14OnlineConsole
{
    public class ConsoleHelper
    {
        public static int GetNumberFromUser()
        {
            bool isUserGood;
            int userGuess;
            do
            {
                var userNumberString = Console.ReadLine();
                isUserGood = int.TryParse(userNumberString, out userGuess);
                if (!isUserGood)
                {
                    Console.WriteLine("It's not a number. Enter NUMBER");
                }
            } while (!isUserGood);

            return userGuess;
        }
    }
}
