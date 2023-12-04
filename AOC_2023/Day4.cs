using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023
{
    public class Day4
    {
        public static void Part1()
        {
            var inputStream = new StreamReader("inputs/04.txt");
            var line = inputStream.ReadLine();
            double totalPoints = 0;
            while (line != null)
            {
                var card = new ScratchCard(line);
                totalPoints += card.Score;
                line = inputStream.ReadLine();
            }
            Console.WriteLine($"The total points of the scratch cards was {totalPoints}");
        }

        public static void Part2()
        {
            var inputStream = new StreamReader("inputs/04.txt");
            var line = inputStream.ReadLine();
            var cards = new List<ScratchCard>();
            var cardMultiplier = new Dictionary<int, int>();
            while (line != null)
            {
                var currentCards = new List<ScratchCard>();
                var scratchCard = new ScratchCard(line);
                currentCards.Add(scratchCard);
                if (cardMultiplier.ContainsKey(scratchCard.CardId))
                {
                    for(var i=0; i< cardMultiplier[scratchCard.CardId]; i++) currentCards.Add(scratchCard);
                }
                foreach (var card in currentCards)
                {
                    for (var i = 1; i <= card.NumberOfWins; i++)
                    {
                        if (cardMultiplier.ContainsKey(scratchCard.CardId + i)) cardMultiplier[scratchCard.CardId + i]++;
                        else cardMultiplier.Add(scratchCard.CardId + i, 1);
                    }

                }
                cards.AddRange(currentCards);
                line = inputStream.ReadLine();
            }
            var sum = cards.Count;
            Console.WriteLine($"The total number of scratch cards was {sum}");
        }

        public class ScratchCard
        {
            public ScratchCard(string input)
            {
                WinningNumbers = new List<int>();
                CardNumbers = new List<int>();

                var cardInfo = input.Split(':');
                int.TryParse(cardInfo[0].Replace("Card ", ""), out int cardId);
                CardId = cardId;
                var cardNumberInfo = cardInfo[1].Split(" |");

                var winningNumbers = cardNumberInfo[0];
                var cardNumbers = cardNumberInfo[1];
                for (int i = 0; i < winningNumbers.Length; i += 3)
                {
                    int.TryParse(winningNumbers.Substring(i, 3), out int num);
                    WinningNumbers.Add(num);
                }
                for (int i = 0; i < cardNumbers.Length; i += 3)
                {
                    int.TryParse(cardNumbers.Substring(i, 3), out int num);
                    CardNumbers.Add(num);
                }
            }
            public int CardId { get; set; }
            public List<int> WinningNumbers { get; set; }
            public List<int> CardNumbers { get; set; }
            public int NumberOfWins => CardNumbers.Count(x => WinningNumbers.Contains(x));
            public double Score => Math.Truncate(Math.Pow(2, NumberOfWins - 1));
        }
    }
}
