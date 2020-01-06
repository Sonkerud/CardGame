using CardGameLibrary;
using CardGameLibrary.Models;
using CardGameLibrary.Models.Entities;
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
        public List<(string,PlayingCard)> playedCards = new List<(string,PlayingCard)>();
        static Random random = new Random();
        public HighscoreService service = new HighscoreService();
        public bool Player1sTurn { get; set; } = true;

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

      
        public Player DecideWinner() => Player1sTurn ? Players[0] : Players[1];
        public void UpdateHighScore()
        {
            CardGameHighScore winner = new CardGameHighScore { Name = DecideWinner().Name };
            service.AddHighScore(winner);
        }

        public bool DecideWhosTurn()
        {
            var card1 = playedCards[playedCards.Count - 2];
            var card2 = playedCards[playedCards.Count - 1];

            if (card2.Item2.Suit != card1.Item2.Suit)
            {
                Player1sTurn = Player1sTurn;
            }
            else if ((int)card2.Item2.Rank <= (int)card1.Item2.Rank)
            {
                Player1sTurn = Player1sTurn;

            }
            else
            {
                Player1sTurn = !Player1sTurn;

            }
            return Player1sTurn;
        }
    }
}
