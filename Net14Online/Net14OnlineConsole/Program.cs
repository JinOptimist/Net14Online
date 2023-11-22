internal class Program
{
    private static void Main(string[] args)
    {
        var minNumber = 150;
        var maxNumber = 2000;
        var totalAttemptCount = CalculateAttempCount(minNumber, maxNumber);
        var random = new Random();
        var theNumber = random.Next(minNumber, maxNumber);
        var isWin = false;

        Console.WriteLine("It's game: Guess the number");

        for (var attempt = 0; attempt < totalAttemptCount; attempt++)
        {
            int userGuess;
            
            Console.WriteLine($"Attempt: {attempt + 1}/{totalAttemptCount}. Range [{minNumber}, {maxNumber}] Enter any number");

            userGuess = GetUserGuess(minNumber, maxNumber);

            if (theNumber == userGuess)
            {
                isWin = true;
                break;
            }
            else
            {
                if (theNumber < userGuess)
                {
                    maxNumber = userGuess - 1;
                    Console.WriteLine(" < ");
                }
                else
                {
                    minNumber = userGuess + 1;
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

    private static int CalculateAttempCount(int minNumber, int maxNumber)
    {
        var numberCount = maxNumber - minNumber + 1;
        var totalAttemptCount = 1;
        var number = 1;
        while (number < numberCount)
        {
            totalAttemptCount++;
            number = number * 2;
        }

        return totalAttemptCount;
    }

    private static int GetUserGuess(int min, int max)
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
            if (userGuess < min)
            {
                Console.WriteLine($"Can't be less then {min}");
                isUserGood = false;
            }
            if (userGuess > max)
            {
                Console.WriteLine($"Can't be more then {max}");
                isUserGood = false;
            }
        } while (!isUserGood);

        return userGuess;
    }
}