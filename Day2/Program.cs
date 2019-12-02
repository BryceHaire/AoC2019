using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> originals = File
                                    .ReadAllText("C:\\Users\\bryce.haire\\AoC\\Day2\\input.txt")
                                    .Split(',')
                                    .Select(s => int.Parse(s))
                                    .ToList();  
            List<int> inputs = originals.ToList();

            for(int index = 0; index < inputs.Count; index = index + 4)
            {
                if(index == 0)
                {
                    inputs[1] = 12;
                    inputs[2] = 2;
                }
                var opCode = inputs[index];
                if(opCode == 99)
                {
                    break;
                }
                var index1 = inputs[index + 1];
                var index2 = inputs[index + 2];
                var index3 = inputs[index + 3];

                var value1 = inputs[index1];
                var value2 = inputs[index2];
                var output = opCode == 1 ? value1 + value2 : value1 * value2;
                inputs[index3] = output;
            }
            Console.WriteLine($"Part 1 Answer: {inputs[0]}");

            for(int noun = 0; noun < 100; noun++)
            {
                for(int verb = 0; verb < 100; verb++)
                {
                    inputs = originals.ToList();
                    for(int index = 0; index < originals.Count; index = index + 4)
                    {
                        if(index == 0)
                        {
                            inputs[1] = noun;
                            inputs[2] = verb;
                        }
                        var opCode = inputs[index];
                        if(opCode == 99)
                        {
                            if(inputs[0] == 19690720)
                            {
                                Console.WriteLine($"Part 2 Answer: {100 * noun + verb}");
                            }

                            break;
                        }
                        var index1 = inputs[index + 1];
                        var index2 = inputs[index + 2];
                        var index3 = inputs[index + 3];

                        var value1 = inputs[index1];
                        var value2 = inputs[index2];
                        var output = opCode == 1 ? value1 + value2 : value1 * value2;
                        inputs[index3] = output;
                    }
                }
            }
        }
    }
}
