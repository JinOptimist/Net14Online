namespace OopExamples
{
    internal class ParamExample
    {
        public static void Do(params string[] strs)
        {
            Console.WriteLine(string.Join(" ", strs));
        }
    }
}
