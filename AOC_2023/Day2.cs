using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023
{
    public class Day2
    {
        public static void Part1()
        {
            var inputStream = new StreamReader("inputs/02.txt");
            var line = inputStream.ReadLine();
            
            var finalSum = 0;
            while (line != null)
            {
                var game = new Game(line);
                if (game.MaxGreen <= 13 && game.MaxRed <= 12 && game.MaxBlue <= 14)
                { 
                    finalSum += game.Id;
                }
                line = inputStream.ReadLine();
            }
            Console.WriteLine($"The sum of possible game Ids is {finalSum}");
        }

        public static void Part2()
        {
            var inputStream = new StreamReader("inputs/02.txt");
            var line = inputStream.ReadLine();
            var finalSum = 0;
            while (line != null)
            {
                var game = new Game(line);
                finalSum += game.Power;
                line = inputStream.ReadLine();
            }
            Console.WriteLine($"The sum of game powers is {finalSum}");
        }

        public class Game
        {
            public Game(string line)
            {
                var gameSplit = line.Split(':');
                int.TryParse(gameSplit[0].Split(' ')[1], out int gameNum);
                Id = gameNum;
                Reveals = gameSplit[1].Split(';').Select(x => new Reveal(x)).ToList();
            }
            public int Id { get; set; }
            public List<Reveal> Reveals { get; set; }
            public int Power => MaxRed * MaxBlue * MaxGreen;
            public int MaxRed => Reveals.Max(x => x.RedCubes);
            public int MaxBlue => Reveals.Max(x => x.BlueCubes);
            public int MaxGreen => Reveals.Max(x => x.GreenCubes);
        }

        public class Reveal
        {
            public Reveal(string input)
            {
                var colors = input.Split(',');
                foreach (var unparsedColor in colors)
                {
                    var colorItem = unparsedColor.Trim().Split(' ');
                    var number = colorItem[0];
                    int.TryParse(number, out int parsedNum);
                    var color = colorItem[1];
                    if (color == "red") RedCubes = parsedNum;
                    else if (color == "blue") BlueCubes = parsedNum;
                    else if (color == "green") GreenCubes = parsedNum;
                }
            }
            public int RedCubes { get; set; }
            public int BlueCubes { get; set; }
            public int GreenCubes { get; set; }
        }
    }
}
