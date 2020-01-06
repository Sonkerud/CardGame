using CardGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.WebASP.Models
{
    public class CardGamesService
    {
        public PlayingCardGame CardGame { get; set; }
        public CardGamesService()
        {
            CardGame = new PlayingCardGame();
        }

        public PlayingCardGame GetNewGame()
        {
            CardGame.AddPlayers("Alexander");
            CardGame.AddPlayers("Sara");
            CardGame.DealCards(5);

            return CardGame;
        }
    }

}
