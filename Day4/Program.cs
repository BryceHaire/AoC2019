using System;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 138241;
            int end = 674034;
            int count = 0;
            int count2 = 0;

            for (int i = start; i <= end; i++)
            {
                bool valid = true;
                int[] intArray = i.ToString().ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
                for (int index = 0; index < intArray.Length - 1; index++)
                {
                    if (intArray[index] > intArray[index + 1])
                    {
                        valid = false;
                    }
                }

                if (intArray.GroupBy(c => c).Any(c => c.Count() > 1) == false)
                {
                    valid = false;
                }

                if(valid)
                {
                    count++;
                }
            }

            Console.Write($"Part 1 Answer {count}");

            for (int i = start; i <= end; i++)
            {
                bool valid = true;
                int[] intArray = i.ToString().ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
                for (int index = 0; index < intArray.Length - 1; index++)
                {
                    if (intArray[index] > intArray[index + 1])
                    {
                        valid = false;
                    }
                }

                if (intArray.GroupBy(c => c).Any(c => c.Count() == 2) == false)
                {
                    valid = false;
                }

                if(valid)
                {
                    count2++;
                }
            }

            Console.Write($"Part 2 Answer {count2}");
        }
    }
}
