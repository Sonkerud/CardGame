using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGame.WebASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.WebASP.Controllers
{
    public class CardGameController : Controller
    {
        CardGamesService service = new CardGamesService();

        [Route ("")]
        [Route ("index")]

        public IActionResult Index()
        {
            var game = service.GetNewGame();
            var cardGameModel = new CardGameVM();
            cardGameModel.Game = game;

            return View(cardGameModel);
        }
    }
}