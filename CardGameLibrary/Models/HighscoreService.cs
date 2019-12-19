using CardGameLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary.Models
{
    public class HighscoreService
    {
        public CardGameHighScoreContext context1 { get; } = new CardGameHighScoreContext();
        private readonly CardGameHighScoreContext context;

        public HighscoreService(CardGameHighScoreContext context)
        {
            this.context = context;
        }
        public HighscoreService()
        {
                
        }

        public  List<CardGameHighScore> HighscoreList()
        {
            return context1.CardGameHighScore.Select(x => x).OrderByDescending(x=>x.NumberOfWins).ToList();
        }

        public void AddHighScore(CardGameHighScore highscore)
        {
            if (context1.CardGameHighScore.Any(x => x.Name == highscore.Name))
            {
                context1.CardGameHighScore.First(x => x.Name == highscore.Name).NumberOfWins++;
            } 
            else
            {

                context1.CardGameHighScore.Add(highscore);
                context1.SaveChanges();
                context1.CardGameHighScore.First(x => x.Name == highscore.Name).NumberOfWins = 1;

            }
            context1.SaveChanges();
        }   
    }
}
