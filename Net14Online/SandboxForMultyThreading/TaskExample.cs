using System.Text;

namespace SandboxForMultyThreading
{
    public class TaskExample
    {
        public static int Index = 0;
        private object syncObj = new();

        public void Say1To100(string name)
        {
            for (int i = 0; i < 30; i++)
            {
                // Check to next Thread
                // T2 force sleep x2
                lock (syncObj)
                {
                    if (Index % 2 == 0)
                    {
                        // Sleep T1
                        Console.WriteLine($"*** {name}: {Index}");
                    }
                    else
                    {
                        Console.WriteLine($"------- {name}: {Index}");
                    }

                    // Sleep T1
                    Index++;
                }

                // Check to next Thread
            }
        }

        public async Task<string> CalcComplexTextAsync(string name, int count)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                // request HTTP API
                sb.Append("name");
            }

            //return Task.Run(() => { return sb.ToString(); });
            return sb.ToString();
        }

        public void M1()
        {
            // wait T2
            lock(syncObj)
            {
                // T1
                Console.WriteLine($"M1 step 1");
                M2();
                Console.WriteLine($"M1 step 2");
            }
        }

        public void M2()
        {
            // wait T1
            lock (syncObj)
            {
                // T2
                Console.WriteLine($"M2 step 1");
                M1();
                Console.WriteLine($"M2 step 2");
            }
        }
    }
}
