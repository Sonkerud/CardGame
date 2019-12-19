using CardGameLibrary.Models;
using CardGameLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public static class CardGameConsoleClasses
    {
           
        


        public static void PlayGame(PlayingCardGame game)
        {
            Console.OutputEncoding = Encoding.UTF8;
            AddPlayersToGame(game);
            Console.Clear();
            game.DealCards(5);
            game.PrintPlayersCards();
            ChangeCards(game);
            RunGame(game);
            Console.Clear();
            Console.WriteLine("The End");
            Console.ReadKey();
        }

        public static void RunGame(PlayingCardGame game)
        {
            Console.Clear();
            bool runGame = true;
            while (runGame)
            {
                bool player1sTurn = true;
                for (int i = 0; i < 5; i++)
                {
                    game.PrintPlayersCards();
                    Console.WriteLine();
                    Console.WriteLine("Played cards:");
                    game.DisplayPlayedCards();
                    Console.WriteLine();
                    if (player1sTurn)
                    {
                        PlayCard(game, 0);
                        Console.WriteLine();
                        PlayCard(game, 1);
                    }
                    else if (!player1sTurn)
                    {
                        PlayCard(game, 1);
                        Console.WriteLine();
                        PlayCard(game, 0);
                    }
                    player1sTurn = DecideWhosTurn(player1sTurn, game);
                    Console.Clear();
                }
                if (player1sTurn)
                {
                    Console.WriteLine($"Congratulations {game.Players[0].Name} you won!");
                    runGame = false;
                }
                else
                {
                    Console.WriteLine($"Congratulations {game.Players[1].Name} you won!");
                    runGame = false;
                }
                Console.ReadKey();
            }
        }
        public static void AddPlayersToGame(PlayingCardGame game)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"Input player {i + 1} name:");
                string playerName = Console.ReadLine();
                game.AddPlayers(playerName);
            }
        }
        public static bool DecideWhosTurn(bool player1sTurn, PlayingCardGame game)
        {
            var card1 = game.playedCards[game.playedCards.Count - 2];
            var card2 = game.playedCards[game.playedCards.Count - 1];

            if (card2.Suit != card1.Suit)
            {
                return player1sTurn;
            }
            else if ((int)card2.Rank <= (int)card1.Rank)
            {
                return player1sTurn;
            }
            else
            {
                return !player1sTurn;
            }
        }

        public static void ChangeCards(PlayingCardGame game)
        {
            for (int i = 0; i < game.Players.Count; i++)
            {
                List<int> idOfCardsToChange = new List<int>();
                Console.WriteLine($"{game.Players[i].Name}: Input nr of card you like to change:");
                int nrOfCardToChange = InputControl.ControlIntInput(0, 5);

                for (int y = 0; y < nrOfCardToChange; y++)
                {
                    int idOfCardToChange = 0;
                    bool input = false;
                    while (!input)
                    {
                        Console.WriteLine("Input id of card you like to change:");

                        try
                        {
                            idOfCardToChange = int.Parse(Console.ReadLine());
                            if (!idOfCardsToChange.Any(x => x == idOfCardToChange))
                            {
                                idOfCardsToChange.Add(idOfCardToChange);
                                input = true;
                            }
                            else
                            {
                                Console.WriteLine("Card doesn't exist!");
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Id");
                        }
                    }
                }

                game.Players[i].ChangeCard(idOfCardsToChange, game);

            }
        }

        public static bool ControlValidCard(int idOfCard, int i, PlayingCardGame game)
        {
            return game.Players[i].DealtHand.Any(x => x.Id == idOfCard);
        }
        public static void PlayCard(PlayingCardGame game, int i)
        {
            Console.WriteLine($"It's {game.Players[i].Name}s turn. Pick a card to play:");

            bool validIdofCard = false;
            while (!validIdofCard)
            {
                var idOfcardToPlay = InputControl.ControlIntInput(1, 5);

                if (game.Players[i].DealtHand.Any(x => x.Id == idOfcardToPlay))
                {

                    var cardToPlay = game.Players[i].DealtHand.Single(x => x.Id == idOfcardToPlay);
                    if (game.playedCards.Count == 0)
                    {
                        game.playedCards.Add(cardToPlay);
                        game.Players[i].PlayCard(idOfcardToPlay);
                        validIdofCard = true;
                        Console.WriteLine($"{game.Players[i].Name} played {cardToPlay.Rank} of {cardToPlay.Symbol}");
                    }
                    else if (game.playedCards.Count % 2 == 0 || game.playedCards[game.playedCards.Count - 1].Suit == cardToPlay.Suit || !game.Players[i].DealtHand.Any(x => x.Suit == game.playedCards[game.playedCards.Count - 1].Suit))
                    {
                        game.playedCards.Add(cardToPlay);
                        game.Players[i].PlayCard(idOfcardToPlay);
                        validIdofCard = true;
                        Console.WriteLine($"{game.Players[i].Name} played {cardToPlay.Rank} of {cardToPlay.Symbol}");
                    }
                    else
                    {
                        Console.WriteLine("Wrong Suit. Chose a valid card.");
                    }
                }
                else
                {
                    Console.WriteLine("Input valid id from remaining card");
                }
            }
        }
    }
}
