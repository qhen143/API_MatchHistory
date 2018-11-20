using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API_MatchHistory.Models
{
    public class MatchHistoryContext : DbContext
    {
        public MatchHistoryContext (DbContextOptions<MatchHistoryContext> options)
            : base(options)
        {
        }

        public DbSet<API_MatchHistory.Models.MatchHistoryItem> MatchHistoryItem { get; set; }
    }
}
