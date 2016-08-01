using Economic_Game__Admin_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic_Game__Admin_.DAL
{
    public class EconomicGameDataContext : DbContext
    {
        public EconomicGameDataContext() : base("EconomicGameDataContext")
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameSettings> GameSettings { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
