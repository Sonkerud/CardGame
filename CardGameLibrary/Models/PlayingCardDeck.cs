using CardGameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary.Models
{
    public class PlayingCardDeck
    {
        public List<PlayingCard> CardDeck { get; set; } = new List<PlayingCard>();
        public List<char> SymbolList = new List<char> 
        {
        '\u2665','\u2660','\u2666','\u2663'
        };

        public PlayingCardDeck()
        {        
            AddCardsToDeck();
        }
        public void InsertCard(PlayingCard card)
        {
            CardDeck.Insert(0, card);
        }

        private void AddCardsToDeck()
        {
            for (int suit = 0; suit < 4; suit++)
            {
                for (int rank = 0; rank < 13; rank++)
                {
                    CardDeck.Add(new PlayingCard {Suit = (Suits)suit, Rank = (Rank)rank, Symbol =  SymbolList[suit]});
                }
            }
        }

    }
}
