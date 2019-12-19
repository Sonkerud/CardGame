using CardGameLibrary;
using CardGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary.Models
{
    public class PlayingCardGame
    {
        public PlayingCardDeck CardDeck { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public List<PlayingCard> playedCards = new List<PlayingCard>();
        static Random random = new Random();

        public PlayingCardGame()
        {
            CardDeck = new PlayingCardDeck();
            CardDeck.CardDeck = ShuffleCardDeck(CardDeck); 
        }

        public void AddPlayers(string name)
        {
                Player player = new Player(name);
                Players.Add(player);
        }
        public  List<PlayingCard> ShuffleCardDeck(PlayingCardDeck cardDeck)
        {
            return cardDeck.CardDeck.OrderBy(c => random.Next()).ToList();
        }
        public  PlayingCard PickCardFromDeck()
        {
            var topInDeck = CardDeck.CardDeck.Where((x, i) => i == CardDeck.CardDeck.Count() - 1).First();
            CardDeck.CardDeck.RemoveAt(CardDeck.CardDeck.Count() - 1);
            return topInDeck;
        }
        public void DealCards(int nrOfCards)
        {
            for (int i = 0; i < Players.Count; i++)
            {
                for (int y = 0; y < nrOfCards; y++)
                {
                    var card = PickCardFromDeck();
                    card.Id = y + 1;
                    Players[i].DealtHand.Add(card);
                }
            }
        }

        public void DisplayPlayedCards()
        {
            foreach (var item in playedCards)
            {
                Console.WriteLine($"{item.Rank} of {item.Symbol}");
            }

        }
    }
}
