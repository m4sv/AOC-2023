using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023
{
    public class Day3
    {
        public static void Part1()
        {
            var inputStream = new StreamReader("inputs/03.txt");
            var schematic = inputStream.ReadToEnd().Split("\r\n").ToList();
            if (string.IsNullOrEmpty(schematic.Last())) schematic.Remove(schematic.Last());
            var partNumbers = new List<PartNumber>();

            for (int y = 0; y < schematic.Count; y++)
            {
                var line = schematic[y];
                for (int x = 0; x < line.Length; x++)
                {
                    var v = line[x];
                    if (isSymbol(v))
                    {
                        if (y > 0) // U
                        {
                            var upValue = schematic[y - 1][x];
                            if (char.IsNumber(upValue))
                            {
                                var partNum = FindNumberInLine(x, schematic[y - 1], y - 1);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }
                        if (y < schematic.Count - 1) // D
                        {
                            var downValue = schematic[y + 1][x];
                            if (char.IsNumber(downValue))
                            {
                                var partNum = FindNumberInLine(x, schematic[y + 1], y + 1);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }
                        if (x > 0) // L
                        {
                            var leftValue = schematic[y][x - 1];
                            if (char.IsNumber(leftValue))
                            {
                                var partNum = FindNumberInLine(x - 1, schematic[y], y);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }
                        if (x < line.Length - 1) // R
                        {
                            var rightValue = schematic[y][x + 1];
                            if (char.IsNumber(rightValue))
                            {
                                var partNum = FindNumberInLine(x + 1, schematic[y], y);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }

                        if (x < line.Length - 1 && y < schematic.Count - 1) // DR
                        {
                            var downRightValue = schematic[y + 1][x + 1];
                            if (char.IsNumber(downRightValue))
                            {
                                var partNum = FindNumberInLine(x + 1, schematic[y + 1], y + 1);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }
                        if (x > 0 && y < schematic.Count - 1) // DL
                        {
                            var downLeftValue = schematic[y + 1][x - 1];
                            if (char.IsNumber(downLeftValue))
                            {
                                var partNum = FindNumberInLine(x - 1, schematic[y + 1], y + 1);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }
                        if (x < line.Length - 1 && y > 0) // UR
                        {
                            var upRightValue = schematic[y - 1][x + 1];
                            if (char.IsNumber(upRightValue))
                            {
                                var partNum = FindNumberInLine(x + 1, schematic[y - 1], y - 1);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }
                        if (x > 0 && y > 0) // UL
                        {
                            var upLeftValue = schematic[y - 1][x - 1];
                            if (char.IsNumber(upLeftValue))
                            {
                                var partNum = FindNumberInLine(x - 1, schematic[y - 1], y - 1);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }
                    }
                }
            }

            var partNumberSum = partNumbers.Select(x => x.Number).Sum();
            Console.WriteLine($"The sum of part numbers is {partNumberSum}");
        }

        public static void Part2()
        {
            var inputStream = new StreamReader("inputs/03.txt");
            var schematic = inputStream.ReadToEnd().Split("\r\n").ToList();
            if (string.IsNullOrEmpty(schematic.Last())) schematic.Remove(schematic.Last());

            var gearSum = 0;
            var partNumbers = new List<PartNumber>();

            for (int y = 0; y < schematic.Count; y++)
            {
                var line = schematic[y];
                for (int x = 0; x < line.Length; x++)
                {
                    var v = line[x];
                    if (v == '*')
                    {
                        partNumbers.Clear();
                        if (y > 0) // U
                        {
                            var upValue = schematic[y - 1][x];
                            if (char.IsNumber(upValue))
                            {
                                var partNum = FindNumberInLine(x, schematic[y - 1], y - 1);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }
                        if (y < schematic.Count - 1) // D
                        {
                            var downValue = schematic[y + 1][x];
                            if (char.IsNumber(downValue))
                            {
                                var partNum = FindNumberInLine(x, schematic[y + 1], y + 1);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }
                        if (x > 0) // L
                        {
                            var leftValue = schematic[y][x - 1];
                            if (char.IsNumber(leftValue))
                            {
                                var partNum = FindNumberInLine(x - 1, schematic[y], y);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }
                        if (x < line.Length - 1) // R
                        {
                            var rightValue = schematic[y][x + 1];
                            if (char.IsNumber(rightValue))
                            {
                                var partNum = FindNumberInLine(x + 1, schematic[y], y);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }

                        if (x < line.Length - 1 && y < schematic.Count - 1) // DR
                        {
                            var downRightValue = schematic[y + 1][x + 1];
                            if (char.IsNumber(downRightValue))
                            {
                                var partNum = FindNumberInLine(x + 1, schematic[y + 1], y + 1);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }
                        if (x > 0 && y < schematic.Count - 1) // DL
                        {
                            var downLeftValue = schematic[y + 1][x - 1];
                            if (char.IsNumber(downLeftValue))
                            {
                                var partNum = FindNumberInLine(x - 1, schematic[y + 1], y + 1);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }
                        if (x < line.Length - 1 && y > 0) // UR
                        {
                            var upRightValue = schematic[y - 1][x + 1];
                            if (char.IsNumber(upRightValue))
                            {
                                var partNum = FindNumberInLine(x + 1, schematic[y - 1], y - 1);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }
                        if (x > 0 && y > 0) // UL
                        {
                            var upLeftValue = schematic[y - 1][x - 1];
                            if (char.IsNumber(upLeftValue))
                            {
                                var partNum = FindNumberInLine(x - 1, schematic[y - 1], y - 1);
                                if (!partNumbers.Any(part => part.X == partNum.X && part.Y == partNum.Y))
                                {
                                    partNumbers.Add(partNum);
                                }
                            }
                        }
                        if(partNumbers.Count == 2)
                        {
                            gearSum += partNumbers[0].Number * partNumbers[1].Number;
                        }
                    }
                }
            }

            Console.WriteLine($"The sum of gear ratios is {gearSum}");
        }

        public static bool isSymbol(char s)
        {
            return !char.IsNumber(s) && s != '.';
        }

        public static PartNumber FindNumberInLine(int index, string line, int y)
        {
            var start = 0;
            var end = 0;
            for (var i = index; i >= 0 && line[i] != '.' && !isSymbol(line[i]); i--) start = i;
            for (var i = index; i < line.Length && line[i] != '.' && !isSymbol(line[i]); i++) end = i;

            int.TryParse(line.Substring(start, end - start + 1), out int resultInt);

            return new PartNumber
            {
                Number = resultInt,
                X = start,
                Y = y
            };
        }

        public class PartNumber
        {
            public int Number { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
