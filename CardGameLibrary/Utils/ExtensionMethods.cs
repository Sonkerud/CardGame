using CardGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary.Utils
{
    public static class ExtensionMethods
    {
        public static void PrintPlayersCards(this PlayingCardGame game)
        {
            foreach (var player in game.Players)
            {
                Console.WriteLine($"{player.Name}");
                foreach (var card in player.DealtHand.OrderBy(x=>x.Id))
                {
                    Console.WriteLine($"{card.Id} {card.Rank} of {card.Symbol}");
                }
                Console.WriteLine();
            }
        }

        public static void PrintPlayersCards(this Player player)
        {
                Console.WriteLine($"{player.Name}");
                foreach (var card in player.DealtHand.OrderBy(x => x.Id))
                {
                    Console.WriteLine($"{card.Id} {card.Rank} of {card.Symbol} - {card.Suit}");
                }
                Console.WriteLine();
            
        }

        public static void DisplayPlayedCards(this PlayingCardGame game)
        {
            Console.WriteLine($"Played cards:");
            foreach (var item in game.playedCards)
            {
                Console.WriteLine($"{item.Item1} played {item.Item2.Rank} of {item.Item2.Symbol}");
            }
            Console.WriteLine();
        }
    }
}
