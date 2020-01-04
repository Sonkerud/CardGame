using CardGameLibrary;
using CardGameLibrary.Models;
using CardGameLibrary.Models.Entities;
using CardGameLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        { 
            PlayingCardGame game = new PlayingCardGame();
            CardGameConsole.StartGame(game);
        }
    }
}
