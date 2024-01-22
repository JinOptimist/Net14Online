using OopExamples;

internal class Program
{
    private static void Main(string[] args)
    {
        ParamExample.Do("Smile");
        ParamExample.Do("Smile", "Fun");
        ParamExample.Do("Smile", "And", "Fun", "4");
    }

    private void AboutVirtualMehtod()
    {
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
    }
}