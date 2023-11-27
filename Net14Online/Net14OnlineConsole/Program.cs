using Net14OnlineConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        var gameBuilder = new GameRuleBuilder();
        var gameRule = gameBuilder.AskUserGame();

        var game = new GuessNumberGame(gameRule);
        game.Play();
    }
}
