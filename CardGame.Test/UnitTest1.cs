using CardGameLibrary.Models;
using System;
using System.Collections.Generic;
using Xunit;


namespace CardGame.Test
{
    public class UnitTest1
    {
        [Fact]
        public void FindCorrectPlayersTurn()
        {
            //arrange
            var game = new PlayingCardGame();
            var expectedPlayer1sTurn = true;
            game.playedCards.Add(("One", new PlayingCard { Id = 1, Suit = CardGameLibrary.Enums.Suits.Hearts, Rank = CardGameLibrary.Enums.Rank.Ace }));
            game.playedCards.Add(("Two", new PlayingCard { Id = 2, Suit = CardGameLibrary.Enums.Suits.Hearts, Rank = CardGameLibrary.Enums.Rank.Deuce }));

            //act
            var turn = game.DecideWhosTurn();

            //Assert
            Assert.Equal(expectedPlayer1sTurn, turn);    

        }

        [Fact]
        public void ShuffleDeck()
        {
            var game = new PlayingCardGame();
            var expectedDeck = game.ShuffleCardDeck(game.CardDeck);

            //Act
            var deck = game.CardDeck.CardDeck;

            //Assert
            Assert.NotEqual(deck, expectedDeck); 

        }
        [Fact]
        public void IsHandARoyalFlushTest()
        {
            var game = new PlayingCardGame();
            game.AddPlayers("Henrik");
            game.Players[0].DealtHand = new List<PlayingCard>{ 
            new PlayingCard {Suit = CardGameLibrary.Enums.Suits.Hearts, Rank = CardGameLibrary.Enums.Rank.Ten},
            new PlayingCard {Suit = CardGameLibrary.Enums.Suits.Hearts, Rank = CardGameLibrary.Enums.Rank.Jack},
            new PlayingCard {Suit = CardGameLibrary.Enums.Suits.Hearts, Rank = CardGameLibrary.Enums.Rank.Queen},
            new PlayingCard {Suit = CardGameLibrary.Enums.Suits.Hearts, Rank = CardGameLibrary.Enums.Rank.King},
            new PlayingCard {Suit = CardGameLibrary.Enums.Suits.Hearts, Rank = CardGameLibrary.Enums.Rank.Ace},
            };

            //Act
            var hand = game.Players[0].IsHandARoyalFlush();

            //Assert
            Assert.True(hand);
        }

        [Fact]
        public void IsHandAStraightFlushTest()
        {
            var game = new PlayingCardGame();
            game.AddPlayers("Henrik");
            game.Players[0].DealtHand = new List<PlayingCard>{
            new PlayingCard {Suit = CardGameLibrary.Enums.Suits.Hearts, Rank = CardGameLibrary.Enums.Rank.Ten},
            new PlayingCard {Suit = CardGameLibrary.Enums.Suits.Hearts, Rank = CardGameLibrary.Enums.Rank.Jack},
            new PlayingCard {Suit = CardGameLibrary.Enums.Suits.Hearts, Rank = CardGameLibrary.Enums.Rank.Queen},
            new PlayingCard {Suit = CardGameLibrary.Enums.Suits.Hearts, Rank = CardGameLibrary.Enums.Rank.King},
            new PlayingCard {Suit = CardGameLibrary.Enums.Suits.Hearts, Rank = CardGameLibrary.Enums.Rank.Nine},
            };

            //Act
            var hand = game.Players[0].IsHandAStraightFlush();

            //Assert
            Assert.True(hand);
        }
    }
}
