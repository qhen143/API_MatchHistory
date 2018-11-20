using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MatchHistory.Models
{
    public class MatchHistoryItem
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string Game { get; set; }
        public string Home { get; set; }
        public string Opposition { get; set; }
        public string Winner { get; set; }
        public string Comment { get; set; }
    }
}
