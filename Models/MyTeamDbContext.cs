using Microsoft.EntityFrameworkCore;

namespace MyTeam.Models
{
    public class MyTeamDbContext : DbContext
    {
        public MyTeamDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players  { get; set; }
        public DbSet<TableItem> TableItems  { get; set; }
        public DbSet<Standings> Standings   { get; set; }
        
    }
}