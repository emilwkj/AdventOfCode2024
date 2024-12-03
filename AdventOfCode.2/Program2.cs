using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode
{
    internal class Two
    {
        // P
        static void Main(string[] args)
        {
            int safeReportsPartOne = Part1();
            int safeReportsPartTwo = Part2();
            var blabla = new Solution();
            var solution = blabla.PartTwo(new StringReader(@"C:\Repos\AdventOfCode\AdventOfCode\AdventOfCode.2\input.txt").ReadToEnd());
        }

        static int Part1()
        {
            int safeReports = 0;

            using (var reader = new StreamReader(@"C:\Repos\AdventOfCode\AdventOfCode\AdventOfCode.2\input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(" ");

                    bool safeReport = true;
                    bool IncreasingReport = int.Parse(values[0]) < int.Parse(values[1]);
                    for (int i = 0; i < values.Length - 1; i++)
                    {
                        if (!validDistanceAndNotEquals(int.Parse(values[i]), int.Parse(values[i + 1])))
                        {
                            safeReport = false;
                        }
                    }
                    if (safeReport) { safeReports++; }

                    bool validDistanceAndNotEquals(int var1, int var2)
                    {
                        Func<int, int, bool> useoperator = null;
                        if (IncreasingReport) { useoperator = (x, y) => x < y; }
                        else { useoperator = (x, y) => x > y; }

                        int distance = Math.Abs(var1 - var2);
                        return (distance > 0 && distance < 4 && useoperator(var1, var2));
                    }

                }
            }
            return safeReports;
        }

        static int Part2()
        {
            int safeReports = 0;

            using (var reader = new StreamReader(@"C:\Repos\AdventOfCode\AdventOfCode\AdventOfCode.2\input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(" ");

                    bool IncreasingReport = int.Parse(values[0]) < int.Parse(values[1]);
                    bool safeReport = true;
                    bool hasUnsafeLevel = false;


                    //FOR HVER KLUMP I HVER LINJE
                    for (int i = 0; i < values.Length - 1 && !hasUnsafeLevel; i++)
                    {
                        //HVIS VALID GØR INGENTING, ELLERS PUT UNSAFELEVELS PÅ MED 1, OG LAV ET NYT ARRAY VI SKAL TJEKKE
                        if (!validDistanceAndNotEquals(int.Parse(values[i]), int.Parse(values[i + 1])))
                        {

                            hasUnsafeLevel = true;
                            List<int[]> arraysToCheck = new List<int[]>();
                            for (int x = 0; x < values.Length; x++)
                            {
                                arraysToCheck.Add(values.Where((v, index) => index != x).Select(v => int.Parse(v)).ToArray());
                            }

                            bool anySafe = false;
                            for (int x = 0; x < arraysToCheck.Count && !anySafe; x++)
                            {
                                if (validateArray(arraysToCheck[x]))
                                {
                                    anySafe = true;
                                }
                            }
                                
                            if(!anySafe)
                            {
                                safeReport = false;
                            }


                            bool validateArray(int[] array)
                            {
                                for (int x = 0; x < array.Length - 1; x++)
                                {
                                    if (!validDistanceAndNotEquals(array[x], array[x + 1]))
                                    {
                                        return false; 
                                    }
                                }
                                return true; 
                            }
                        }
                        }
                    //SUB FUNKTION
                    bool validDistanceAndNotEquals(int var1, int var2)
                    {
                        Func<int, int, bool> useoperator = null;
                        if (IncreasingReport) { useoperator = (x, y) => x < y; }
                        else { useoperator = (x, y) => x > y; }

                        int distance = Math.Abs(var1 - var2);
                        return (distance > 0 && distance < 4 && useoperator(var1, var2));
                    }
                    if (safeReport) { safeReports++; }
                    }
                }
                return safeReports;
            }

        }
    }