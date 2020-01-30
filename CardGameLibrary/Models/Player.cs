using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<PlayingCard> DealtHand { get; set; }
        public int StrengthOfHand { get; set; }

        public Player(string name)
        {
            Name = name;
            DealtHand = new List<PlayingCard>();
           
        }
        public void ChangeCard(List<int> idOfCardsToChange, PlayingCardGame game)
        {
            foreach (var cards in idOfCardsToChange)
            {
                var cardToChange = DealtHand.First(x => x.Id == cards);
                var newCard = game.PickCardFromDeck();
                newCard.Id = cardToChange.Id;
                DealtHand.Remove(cardToChange);
                DealtHand.Add(newCard);
            }
        }
        public PlayingCard PlayCard(int cardNr)
        {
            var cardToPlay = DealtHand.FirstOrDefault(x => x.Id == cardNr);
            DealtHand.Remove(cardToPlay);
            return cardToPlay;
        }
        public void StrengthOfHandCalculator()
        {
            /* 
           10. Royal
           9. Straight Flush
           8. Fyrtal
           7. Kåk
           6. Färg
           5. Stege
           4. Triss
           3. Tvåpar
           2. Par
           1. High card
           */

            if (DealtHand != null && DealtHand.Count != 0)
            {
                IsHandAFlush();
                IsHandAStraight();
            }
        }

        public bool IsHandAFlush() => DealtHand == null || DealtHand.Count == 0 ? false : DealtHand.All(x => x.Suit == Enums.Suits.Clubs || x.Suit == Enums.Suits.Diamonds || x.Suit == Enums.Suits.Hearts || x.Suit == Enums.Suits.Spades) ? true : false;

        public bool IsHandARoyalFlush() => IsHandAFlush() ? IsHandAStraight() : DealtHand.Max(x => (int)x.Rank ) == (int)Enums.Rank.Ace;
        

        public bool IsHandAStraightFlush() => IsHandAFlush() ? IsHandAStraight() : false;

        public bool IsHandAStraight()
        {
            var orderedHand = DealtHand.OrderBy(x => x.Rank).ToList();
         
            bool result = false;
            if (DealtHand != null && DealtHand.Count != 0)
            {
                if (orderedHand[0].Rank != Enums.Rank.Ten)
                {
                           if ((int)orderedHand[1].Rank == (int)orderedHand[0].Rank + 1 
                            && (int)orderedHand[2].Rank == (int)orderedHand[1].Rank + 1
                            && (int)orderedHand[3].Rank == (int)orderedHand[2].Rank + 1
                            && (int)orderedHand[4].Rank == (int)orderedHand[3].Rank + 1
                            )
                            {
                                result = true;
                            } 
                } 
                else
                {
                    if ((int)orderedHand[1].Rank == (int)orderedHand[0].Rank + 1
                            && (int)orderedHand[2].Rank == (int)orderedHand[1].Rank + 1
                            && (int)orderedHand[3].Rank == (int)orderedHand[2].Rank + 1
                            && (int)orderedHand[4].Rank == (int)Enums.Rank.Ace
                            )
                    {
                         result = true;
                    }
                }
            }
            return result;
        }
    }
}
