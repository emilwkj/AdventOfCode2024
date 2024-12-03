using System;

namespace AdventOfCode
{
    internal class Two
    {
        static void Main(string[] args)
        {
            int totalDistance = 0;
            List<int> listOne = new List<int>();
            List<int> listTwo = new List<int>();
            using (var reader = new StreamReader(@"C:\Repos\AdventOfCode\AdventOfCode\AdventOfCode.1\Input.txt"))
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

            Console.WriteLine(totalDistance);
        }
    }
}