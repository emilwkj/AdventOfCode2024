using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode
{
    internal class TwoGPT
    {
        static void MainGPT(string[] args)
        {
            int safeReportsPartOne = Part1();
            int safeReportsPartTwo = Part2();

            Console.WriteLine($"Safe reports in Part 1: {safeReportsPartOne}");
            Console.WriteLine($"Safe reports in Part 2: {safeReportsPartTwo}");
        }

        // Part 1: Basic safety check - no removal of levels
        static int Part1()
        {
            int safeReports = 0;

            using (var reader = new StreamReader(@"C:\Repos\AdventOfCode\AdventOfCode.2\input.txt"))  // Ensure the file path is correct
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(" ");

                    if (IsSafeReport(values))
                    {
                        safeReports++;
                    }
                }
            }
            return safeReports;
        }

        // Part 2: Safety check with removal of one unsafe level
        static int Part2()
        {
            int safeReports = 0;

            using (var reader = new StreamReader(@"C:\Repos\AdventOfCode\AdventOfCode\AdventOfCode.2\input.txt"))  // Ensure the file path is correct
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(" ");

                    // Check if the report is safe or if removing one level makes it safe
                    if (IsSafeReport(values) || CanBeMadeSafeWithOneRemoval(values))
                    {
                        safeReports++;
                    }
                }
            }

            return safeReports;
        }

        // Function to check if the report is safe (no removal)
        static bool IsSafeReport(string[] values)
        {
            bool increasing = int.Parse(values[0]) < int.Parse(values[1]);
            for (int i = 0; i < values.Length - 1; i++)
            {
                int var1 = int.Parse(values[i]);
                int var2 = int.Parse(values[i + 1]);
                int distance = Math.Abs(var1 - var2);

                // Check the distance condition and increasing/decreasing trend
                if (distance < 1 || distance > 3 || (increasing && var1 >= var2) || (!increasing && var1 <= var2))
                {
                    return false;
                }
            }
            return true;
        }

        // Function to check if the report can be made safe by removing one level
        static bool CanBeMadeSafeWithOneRemoval(string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                var modifiedReport = values.Where((v, index) => index != i).ToArray();  // Remove the current element
                if (IsSafeReport(modifiedReport))  // Check if the new report is safe
                {
                    return true;
                }
            }
            return false;
        }
    }
}
