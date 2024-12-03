using System;

namespace AdventOfCode
{
    internal class One
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Part1());
            Console.WriteLine(Part2());
        }


        static string Part2()
        {
            int similarityScore = 0;
            List<int> listOne = new List<int>();
            List<int> listTwo = new List<int>();
            using (var reader = new StreamReader(@"C:\Repos\AdventOfCode\AdventOfCode.1\input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split("   ");
                    listOne.Add(int.Parse(values[0]));
                    listTwo.Add(int.Parse(values[1]));
                }
            }

            listOne.ForEach(x =>
            {
                similarityScore = similarityScore + x * listTwo.Count(y => y == x);
            });
            return similarityScore.ToString();
        }

        static string Part1() {
            int totalDistance = 0;
            List<int> listOne = new List<int>();
            List<int> listTwo = new List<int>();
            using (var reader = new StreamReader(@"C:\Repos\AdventOfCode\AdventOfCode.1\input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split("   ");
                    listOne.Add(int.Parse(values[0]));
                    listTwo.Add(int.Parse(values[1]));
                }
            }
            listOne.Sort();
            listTwo.Sort();
            for (int i = 0; i < listOne.Count; i++)
            {
                totalDistance = totalDistance + Math.Abs(listOne[i] - listTwo[i]);
            }

            return totalDistance.ToString();
        }
    }
}