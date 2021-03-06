﻿using CardGameLibrary.Models;
using CardGameLibrary.Models.Entities;
using CardGameLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public static class CardGameConsole
    {
        public static void StartGame(PlayingCardGame game)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---Cardgame 2032----");
                Console.WriteLine("1. Play Game");
                Console.WriteLine("2. Show Highscore");
                Console.WriteLine("3. Show rules");
                Console.WriteLine("4. Play Game\n");

                ConsoleKeyInfo key = new ConsoleKeyInfo();
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        PlayGame(game);
                        break;
                    case ConsoleKey.D2:
                        DisplayHighScore(game);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        DisplayRules();
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }
        }
        public static void PlayGame(PlayingCardGame game)
        {
            Console.OutputEncoding = Encoding.UTF8;
            AddPlayersToGame(game);
            Console.Clear();
            game.DealCards(5);
            game.Players[0].StrengthOfHandCalculator();
            game.Players[1].StrengthOfHandCalculator();

            ChangeCards(game);
            RunGame(game);
            game.DecideWinner();
            game.UpdateHighScore();
            Console.Clear();
            DisplayHighScore(game);
            Console.ReadKey();
        }
        public static void RunGame(PlayingCardGame game)
        {
            Console.Clear();
                
                for (int i = 0; i < 5; i++)
                {
                    
                    if (game.Player1sTurn)
                    {
                        PlayCard(game, 0);
                       
                        PlayCard(game, 1);
                    }
                    else if (!game.Player1sTurn)
                    {
                        PlayCard(game, 1);
                       
                        PlayCard(game, 0);
                    }
                    game.DecideWhosTurn();
                    
                    Console.Clear();
                }
                PrintWinner(game);
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
        public static void PrintWinner(PlayingCardGame game)
        {
            if (game.Player1sTurn)
            {
                Console.WriteLine($"Congratulations {game.Players[0].Name} you won!");
            }
            else
            {
                Console.WriteLine($"Congratulations {game.Players[1].Name} you won!");
            }
            Console.ReadKey();
        }
        public static void ChangeCards(PlayingCardGame game)
        {
            for (int i = 0; i < game.Players.Count; i++)
            {
                Console.WriteLine($"{game.Players[i].Name}, press enter to see your hand: ");
                Console.ReadLine();
                game.Players[i].PrintPlayersCards();
                List<int> idOfCardsToChange = new List<int>();
                Console.WriteLine($"{game.Players[i].Name}: Input nr of cards you like to change:");
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
                Console.Clear();
            }
        }
        public static bool ControlValidCard(int idOfCard, int i, PlayingCardGame game)
        {
            return game.Players[i].DealtHand.Any(x => x.Id == idOfCard);
        }
        public static void PlayCard(PlayingCardGame game, int i)
        {
            if (game.playedCards.Count != 0)
            {
                game.DisplayPlayedCards();
            }
            Console.WriteLine($"It's {game.Players[i].Name}s turn. Pick a card to play:\n");
            Console.WriteLine("Press enter to see hand:\n");
            Console.ReadKey(true);
            game.Players[i].PrintPlayersCards();
            bool validIdofCard = false;
            while (!validIdofCard)
            {
                var idOfcardToPlay = InputControl.ControlIntInput(1, 5);

                if (game.Players[i].DealtHand.Any(x => x.Id == idOfcardToPlay))
                {
                    var cardToPlay = game.Players[i].DealtHand.Single(x => x.Id == idOfcardToPlay);
                    if (game.playedCards.Count == 0)
                    {
                        game.playedCards.Add((game.Players[i].Name, cardToPlay));
                        game.Players[i].PlayCard(idOfcardToPlay);
                        validIdofCard = true;
                       
                    }
                    else if (game.playedCards.Count % 2 == 0 || game.playedCards[game.playedCards.Count - 1].Item2.Suit == cardToPlay.Suit || !game.Players[i].DealtHand.Any(x => x.Suit == game.playedCards[game.playedCards.Count - 1].Item2.Suit))
                    {
                        game.playedCards.Add((game.Players[i].Name,cardToPlay));
                        game.Players[i].PlayCard(idOfcardToPlay);
                        validIdofCard = true;
                        
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
            Console.Clear();
        }
        public static void DisplayHighScore(PlayingCardGame game)
        {
            Console.Clear();
            var highscoreList = game.service.HighscoreList();
            Console.WriteLine("Highscore:");
            Console.WriteLine();
            for (int i = 0; i < highscoreList.Count(); i++)
            {

                Console.WriteLine($"{i+1}. {highscoreList[i].Name} Wins: {highscoreList[i].NumberOfWins}");
            }
        }
        public static void DisplayRules()
        {
            Console.Clear();
            Console.WriteLine("Rules:");
            Console.WriteLine("- Cardgame for 2 players");
            Console.WriteLine("- Both players starts with five cards.");
            Console.WriteLine("- Both players get one opportunity to change as many cards as they like.");
            Console.WriteLine("- You have to follow suit. Highest rank in correct suit continue to play.");
            Console.WriteLine("- Winner of last round wins the game.");

        }
    }
}
