using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023
{
    public class Day1
    {
        public static void Part1()
        {
            var inputStream = new StreamReader("inputs/01.txt");
            var line = inputStream.ReadLine();

            var calibrationValues = new List<int>();

            while (line != null)
            {
                var digits = line.Where(x => char.IsNumber(x)).ToList();
                var calibrationString = $"{digits.FirstOrDefault()}{digits.LastOrDefault()}";
                int.TryParse(calibrationString, out int calibrationValue);
                calibrationValues.Add(calibrationValue);
                line = inputStream.ReadLine();
            }

            Console.WriteLine($"Sum of all Calibration Values: {calibrationValues.Sum()}");
        }

        public static void Part2()
        {
            var inputStream = new StreamReader("inputs/01.txt");
            var line = inputStream.ReadLine();

            var calibrationValues = new List<int>();

            while (line != null)
            {
                line = ReplaceNumbersWithSafeDigits(line);
                var digits = line.Where(x => char.IsNumber(x)).ToList();
                var calibrationString = $"{digits.FirstOrDefault()}{digits.LastOrDefault()}";
                int.TryParse(calibrationString, out int calibrationValue);
                calibrationValues.Add(calibrationValue);
                line = inputStream.ReadLine();
            }

            Console.WriteLine($"Sum of all Calibration Values: {calibrationValues.Sum()}");
        }

        static string ReplaceNumbersWithSafeDigits(string input)
        {
            var numberDict = new Dictionary<string, int>()
            {
                { "zero", 0 },
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 },
            };

            foreach (var number in numberDict)
            {
                var replaceValue = $"{number.Key.First()}{number.Value.ToString()}{number.Key.Last()}";
                input = input.Replace(number.Key, replaceValue);
            }
            return input;
        }
    }
}
