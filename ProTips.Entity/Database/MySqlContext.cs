using Microsoft.EntityFrameworkCore;
using ProTips.Entity.Models;

namespace ProTips.Entity.Database;

public class MySqlContext : DbContext
{
    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
    {
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<BetStrategy> BetStrategies { get; set; }
    public DbSet<Bet> Bets { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Team

        modelBuilder.Entity<Team>(mb =>
        {
            mb.ToTable("teams");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
            mb.Property(x => x.Image).HasColumnName("image");
            mb.Property(x => x.LeagueId).HasColumnName("leagueId");
            mb.Property(x => x.CountryId).HasColumnName("countryId");
        });

        modelBuilder.Entity<Team>()
            .HasOne<League>()
            .WithMany(x => x.Teams)
            .HasForeignKey(x => x.LeagueId);
        modelBuilder.Entity<Team>()
            .HasOne<Country>()
            .WithMany()
            .HasForeignKey(x => x.CountryId);

        #endregion
        
        #region Result
        
        modelBuilder.Entity<Result>(mb =>
        {
            mb.ToTable("results");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.GameId).HasColumnName("gameId");
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
            mb.Property(x => x.HalfTimeGoalsHome).HasColumnName("halfTimeGoalsHome");
            mb.Property(x => x.HalfTimeGoalsAway).HasColumnName("halfTimeGoalsAway");
            mb.Property(x => x.FullTimeGoalsHome).HasColumnName("fullTimeGoalsHome");
            mb.Property(x => x.FullTimeGoalsAway).HasColumnName("fullTimeGoalsAway");
        });

        #endregion

        #region League

        modelBuilder.Entity<League>(mb =>
        {
            mb.ToTable("leagues");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
        });
        
        modelBuilder.Entity<League>()
            .HasMany<Team>(x => x.Teams)
            .WithOne()
            .HasForeignKey(x => x.LeagueId);
        
        #endregion
        
        #region Game
        
        modelBuilder.Entity<Game>(mb =>
        {
            mb.ToTable("games");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
            mb.Property(x => x.HomeId).HasColumnName("homeId");
            mb.Property(x => x.AwayId).HasColumnName("awayId");
            mb.Property(x => x.ResultId).HasColumnName("resultId");
            mb.Property(x => x.Date).HasColumnName("date");
        });
        
        modelBuilder.Entity<Game>()
            .HasOne<Team>(x => x.Home)
            .WithMany()
            .HasForeignKey(x => x.HomeId);        
        modelBuilder.Entity<Game>()
            .HasOne<Team>(x => x.Away)
            .WithMany()
            .HasForeignKey(x => x.AwayId);        
        modelBuilder.Entity<Game>()
            .HasOne<Result>(x => x.Result)
            .WithOne(x => x.Game)
            .HasForeignKey<Game>(x => x.ResultId);
        
        #endregion
        
        #region Country

        modelBuilder.Entity<Country>(mb =>
        {
            mb.ToTable("countries");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
        });
        
        modelBuilder.Entity<Country>()
            .HasMany<Team>(x => x.Teams)
            .WithOne()
            .HasForeignKey(x => x.CountryId);

        #endregion
        
        #region BetStrategy
        
        modelBuilder.Entity<BetStrategy>(mb =>
        {
            mb.ToTable("betStrategies");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
            mb.Property(x => x.Description).HasColumnName("description");
        });
        
        #endregion
        
        #region Bet

        modelBuilder.Entity<Bet>(mb =>
        {
            mb.ToTable("bets");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
            mb.Property(x => x.Value).HasColumnName("value").HasPrecision(2);
            mb.Property(x => x.Result).HasColumnName("result").HasPrecision(2);
            mb.Property(x => x.Odd).HasColumnName("odd").HasPrecision(2);
            mb.Property(x => x.StrategyId).HasColumnName("strategyId");
            mb.Property(x => x.GameId).HasColumnName("gameId");
            mb.Property(x => x.Winner).HasColumnName("winner");
        });
        
        modelBuilder.Entity<Bet>()
            .HasOne<BetStrategy>(x => x.BetStrategy)
            .WithMany()
            .HasForeignKey(x => x.StrategyId);
        modelBuilder.Entity<Bet>()
            .HasOne<Game>(x => x.Game)
            .WithMany()
            .HasForeignKey(x => x.GameId);

        #endregion
    }
}