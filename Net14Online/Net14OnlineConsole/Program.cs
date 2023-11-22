var number = 42;

Console.WriteLine("It's game: Guess the number");
Console.WriteLine("Enter any number");

int userGuess;
bool isUserGood;
do
{
    var userNumberString = Console.ReadLine();
    isUserGood = int.TryParse(userNumberString, out userGuess);
    if (!isUserGood)
    {
        Console.WriteLine("It's not a number. Enter NUMBER");
    }
} while (!isUserGood);

if (number == userGuess)
{
    Console.WriteLine("Win!!!");
}
else
{
    Console.WriteLine("Looser");
}

