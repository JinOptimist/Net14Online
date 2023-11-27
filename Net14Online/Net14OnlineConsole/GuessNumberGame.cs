using Net14OnlineConsole.Models;

namespace Net14OnlineConsole
{
    public class GuessNumberGame
    {
        public GuessNumberGame(GameRule gameRule)
        {
            GameRule = gameRule;
        }

        private GameRule GameRule { get; set; }

        public void Play()
        {
            var isWin = false;

            Console.WriteLine("It's game: Guess the number");

            for (var attempt = 0; attempt < GameRule.MaxAttemptCount; attempt++)
            {
                int userGuess;

                Console.WriteLine($"Attempt: {attempt + 1}/{GameRule.MaxAttemptCount}. Range [{GameRule.MinNumber}, {GameRule.MaxNumber}] Enter any number");

                userGuess = GetUserGuess();

                if (GameRule.TheNumber == userGuess)
                {
                    isWin = true;
                    break;
                }
                else
                {
                    if (GameRule.TheNumber < userGuess)
                    {
                        GameRule.MaxNumber = userGuess - 1;
                        Console.WriteLine(" < ");
                    }
                    else
                    {
                        GameRule.MinNumber = userGuess + 1;
                        Console.WriteLine(" > ");
                    }
                }
            }

            if (isWin)
            {
                Console.WriteLine("Win!!!");
            }
            else
            {
                Console.WriteLine("Loose");
            }

            Console.WriteLine("The end");
        }

        private int GetUserGuess()
        {
            bool isUserGood = true;
            int userGuess;
            do
            {
                userGuess = ConsoleHelper.GetNumberFromUser();
                if (userGuess < GameRule.MinNumber)
                {
                    Console.WriteLine($"Can't be less then {GameRule.MinNumber}");
                    isUserGood = false;
                }
                if (userGuess > GameRule.MaxNumber)
                {
                    Console.WriteLine($"Can't be more then {GameRule.MaxNumber}");
                    isUserGood = false;
                }
            } while (!isUserGood);

            return userGuess;
        }
    }
}
