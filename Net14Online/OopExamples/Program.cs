using OopExamples;

// SOLID

// L

var humans = new List<Human>();

var petr = new Human();
humans.Add(petr);
var olga = new Girl();
humans.Add(olga);

foreach (Human human in humans)
{
    Console.WriteLine(human.HowOldAreYou());
}

Console.ReadLine();