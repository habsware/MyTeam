using Microsoft.EntityFrameworkCore;

namespace MyTeam.Models
{
    public class MyTeamDbContext : DbContext
    {
        public MyTeamDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Match>()
                .HasOne(t => t.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Match>()
                .HasOne(t => t.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
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