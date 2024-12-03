using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode._3
{
    internal class Part1
    {
        /*
        static void Main(string[] args)
        {
            string contents = File.ReadAllText(@"C:\Repos\AdventOfCode\AdventOfCode\AdventOfCode.3\input.txt");
            var matches = Regex.Matches(contents, @"mul\([0-9]?[0-9]?[0-9],[0-9]?[0-9]?[0-9]\)");
            int totalNumber = 0;
            foreach (Match match in matches) { 
                string[] numbers = match.Value.Replace("mul(", "").Replace(")", "").Split(',');
                totalNumber = totalNumber + int.Parse(numbers[0]) * int.Parse(numbers[1]);
            }

            Console.WriteLine(totalNumber);
        }
        */
    }
}
