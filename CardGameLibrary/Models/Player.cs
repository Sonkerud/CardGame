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
    }
}
