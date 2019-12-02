using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputs = File
                                    .ReadAllLines("C:\\Users\\bryce.haire\\AoC\\Day1\\input.txt")
                                    .Select(s => int.Parse(s))
                                    .ToList();           
            List<int> answer1 = new List<int>();
            List<int> answer2 = new List<int>();
            foreach(var input in inputs)
            {
                var modulo = input % 3;
                var calculate = ((input - modulo) / 3) -2;
                answer1.Add(calculate);
            }

            Console.WriteLine($"Part 1 Answer: {answer1.Sum()}");

            foreach(var input in inputs)
            {
                var modulo = input % 3;
                var calculate = ((input - modulo) / 3) -2;
                answer2.Add(calculate);
                while(calculate > 3)
                {
                    modulo = calculate % 3;
                    calculate = ((calculate - modulo) / 3) -2;
                    if(calculate > 0)
                    {
                        answer2.Add(calculate);
                    }
                }
            }

            Console.WriteLine($"Part 2 Answer: {answer2.Sum()}");
        }
    }
}
