namespace OopExamples
{
    public class Human
    {
        protected int age = 20;

        public virtual string HowOldAreYou()
        {
            return $"I'm {age} old";
        }
    }
}
