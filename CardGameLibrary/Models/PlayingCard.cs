using CardGameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary.Models
{
    public class PlayingCard
    {
        public Suits Suit { get; set; }
        public Rank Rank { get; set; }
        public int Id { get; set; }
        public char Symbol { get; set; }

        public override string ToString()
        {
            return $"{Rank} of {Symbol}";
        }
    }
}
