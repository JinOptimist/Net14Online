using Net14OnlineConsole.Models;

namespace Net14OnlineConsole
{
    public class GameRuleBuilder
    {
        public GameRule AskUserGame()
        {
            Console.WriteLine("This is a game Guess the Number");
            Console.WriteLine("If you want to play with [B]ot enter B");
            Console.WriteLine("If you want to play with [U]ser enter U");

            var userAnsewr = Console.ReadLine();

            switch (userAnsewr)
            {
                case "B":
                    return BuildDefaultRule();
                case "U":
                    return BuildRuleByUser();
            }

            return null;
        }

        private GameRule BuildRuleByUser()
        {
            var rule = new GameRule();

            Console.WriteLine("Enter min number");
            rule.MinNumber = ConsoleHelper.GetNumberFromUser();

            Console.WriteLine("Enter max number");
            rule.MaxNumber = ConsoleHelper.GetNumberFromUser();

            Console.WriteLine("Enter the number");
            rule.TheNumber = ConsoleHelper.GetNumberFromUser();

            Console.Clear();

            rule.MaxAttemptCount = CalculateAttempCount(rule.MinNumber, rule.MaxNumber);
            return rule;
        }

        private GameRule BuildDefaultRule()
        {
            var rule = new GameRule();

            rule.MinNumber = 1;
            rule.MaxNumber = 100;
            rule.MaxAttemptCount = CalculateAttempCount(rule.MinNumber, rule.MaxNumber);
            var random = new Random();
            rule.TheNumber = random.Next(rule.MinNumber, rule.MaxNumber);

            return rule;
        }

        private int CalculateAttempCount(int minNumber, int maxNumber)
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

    }
}
