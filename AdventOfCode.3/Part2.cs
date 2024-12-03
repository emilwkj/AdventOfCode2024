using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode._3
{
    internal class Part2
    {
        static void Main(string[] args)
        {
            string contents = File.ReadAllText(@"C:\Repos\AdventOfCode\AdventOfCode\AdventOfCode.3\input.txt");
            var matches = Regex.Matches(contents, @"mul\([0-9]?[0-9]?[0-9],[0-9]?[0-9]?[0-9]\)|don't\(\)|do\(\)");
            int totalNumber = 0;
            bool enabled = true;
            foreach (Match match in matches)
            {
                if (Regex.Match(match.Value, @"don't\(\)").Success)
                {
                    enabled = false;
                }
                else if (Regex.Match(match.Value, @"do\(\)").Success)
                {
                    enabled = true;
                }
                else if (Regex.Match(match.Value, @"mul\([0-9]?[0-9]?[0-9],[0-9]?[0-9]?[0-9]\)").Success && enabled)
                {
                    string[] numbers = match.Value.Replace("mul(", "").Replace(")", "").Split(',');
                    totalNumber = totalNumber + int.Parse(numbers[0]) * int.Parse(numbers[1]);
                } 
            }
            Console.WriteLine(totalNumber);
        }
    }
}
