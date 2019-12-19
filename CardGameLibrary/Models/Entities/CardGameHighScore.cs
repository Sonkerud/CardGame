using System;
using System.Collections.Generic;

namespace CardGameLibrary.Models.Entities
{
    public partial class CardGameHighScore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? NumberOfWins { get; set; }
    }
}
