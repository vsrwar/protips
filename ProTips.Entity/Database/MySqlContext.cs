using Microsoft.EntityFrameworkCore;
using ProTips.Entity.Models;

namespace ProTips.Entity.Database;

public class MySqlContext : DbContext
{
    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
    {
    }

    public DbSet<Bet> Bets { get; set; }
    public DbSet<BetStrategy> BetStrategies { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<League> Leagues { set; get; }
    public DbSet<Link> Links { set; get; }
    public DbSet<PreLive> PreLives { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Tip> Tips { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<WalletTransaction> WalletsWalletTransactions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Bet

        modelBuilder.Entity<Bet>(mb =>
        {
            mb.ToTable("bets");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
            mb.Property(x => x.Value).HasColumnName("value").HasColumnType("DECIMAL(7, 2)");
            mb.Property(x => x.Result).HasColumnName("result").HasColumnType("DECIMAL(7, 2)");
            mb.Property(x => x.Odd).HasColumnName("odd").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.StrategyId).HasColumnName("strategyId");
            mb.Property(x => x.GameId).HasColumnName("gameId");
            mb.Property(x => x.Winner).HasColumnName("winner");
            mb.Property(x => x.UserId).HasColumnName("userId");
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
        
        #region Country

        modelBuilder.Entity<Country>(mb =>
        {
            mb.ToTable("countries");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
            mb.Property(x => x.Image).HasColumnName("image");
        });
        
        modelBuilder.Entity<Country>()
            .HasMany<Team>(x => x.Teams)
            .WithOne()
            .HasForeignKey(x => x.CountryId);
        modelBuilder.Entity<Country>()
            .HasMany<League>(x => x.Leagues)
            .WithOne()
            .HasForeignKey(x => x.CountryId);

        #endregion
        
        #region Currency

        modelBuilder.Entity<Currency>(mb =>
        {
            mb.ToTable("currencies");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
            mb.Property(x => x.Symbol).HasColumnName("symbol");
            mb.Property(x => x.ShortName).HasColumnName("shortName");
        });

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
            .WithOne()
            .HasForeignKey<Result>(x => x.GameId);
        modelBuilder.Entity<Game>()
            .HasMany<Link>(x => x.Links)
            .WithOne()
            .HasForeignKey(x => x.GameId);
        
        #endregion
        
        #region League

        modelBuilder.Entity<League>(mb =>
        {
            mb.ToTable("leagues");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
            mb.Property(x => x.Image).HasColumnName("image");
        });
        
        modelBuilder.Entity<League>()
            .HasMany<Team>(x => x.Teams)
            .WithOne()
            .HasForeignKey(x => x.LeagueId);
        
        #endregion
        
        #region Link

        modelBuilder.Entity<Link>(mb =>
        {
            mb.ToTable("links");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
            mb.Property(x => x.Url).HasColumnName("url");
            mb.Property(x => x.GameId).HasColumnName("gameId");
        });

        #endregion
        
        #region PreLive
        
        modelBuilder.Entity<PreLive>(mb =>
        {
            mb.ToTable("prelives");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
            mb.Property(x => x.GameId).HasColumnName("gameId");
            mb.Property(x => x.HomeOdd).HasColumnName("homeOdd").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.DrawOdd).HasColumnName("drawOdd").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.AwayOdd).HasColumnName("awayOdd").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.AvgGoalsHomeAtHome).HasColumnName("avgGoalsHomeAtHome").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.AvgGoalsAwayAtAway).HasColumnName("avgGoalsAwayAtAway").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.AvgGoalsHomeVsAway).HasColumnName("avgGoalsHomeVsAway").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.AvgGoalsHalfTime).HasColumnName("avgGoalsHalfTime").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.AvgOver1_5GoalsHome).HasColumnName("avgOver1_5GoalsHome").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.AvgOver1_5GoalsAway).HasColumnName("avgOver1_5GoalsAway").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.AvgUnder2_5GoalsHome).HasColumnName("avgUnder2_5GoalsHome").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.AvgUnder2_5GoalsAway).HasColumnName("avgUnder2_5GoalsAway").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.AvgUnder3_5GoalsHome).HasColumnName("avgUnder3_5GoalsHome").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.AvgUnder3_5GoalsAway).HasColumnName("avgUnder3_5GoalsAway").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.AvgGoalsMomentHome).HasColumnName("avgGoalsMomentHome").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.AvgGoalsMomentAway).HasColumnName("avgGoalsMomentAway").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.PossibleResults).HasColumnName("possibleResults");
            mb.Property(x => x.AvgBothTeamsToScoreHome).HasColumnName("avgBothTeamsToScoreHome").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.AvgBothTeamsToScoreAway).HasColumnName("avgBothTeamsToScoreAway").HasColumnType("DECIMAL(4, 2)");
            mb.Property(x => x.GameRelevance).HasColumnName("gameRelevance");
            mb.Property(x => x.NeedVictoryTeamId).HasColumnName("needVictoryTeamId");
        });
        
        modelBuilder.Entity<PreLive>()
            .HasOne<Game>(x => x.Game)
            .WithOne()
            .HasForeignKey<PreLive>(x => x.GameId);
        
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

        #endregion

        #region Tip

        modelBuilder.Entity<Tip>(mb =>
        {
            mb.ToTable("tips");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
            mb.Property(x => x.GameId).HasColumnName("gameId");
            mb.Property(x => x.BetStrategyId).HasColumnName("betStrategyId");
            mb.Property(x => x.PreLiveId).HasColumnName("preLiveId");
        });

        modelBuilder.Entity<Tip>()
            .HasOne<Game>(x => x.Game)
            .WithMany()
            .HasForeignKey(x => x.GameId);
        modelBuilder.Entity<Tip>()
            .HasOne<BetStrategy>(x => x.BetStrategy)
            .WithMany()
            .HasForeignKey(x => x.BetStrategyId);
        modelBuilder.Entity<Tip>()
            .HasOne<PreLive>(x => x.PreLive)
            .WithMany()
            .HasForeignKey(x => x.PreLiveId);
        
        #endregion
        
        #region User
        
        modelBuilder.Entity<User>(mb =>
        {
            mb.ToTable("users");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
            mb.Property(x => x.Email).HasColumnName("email");
            mb.Property(x => x.Password).HasColumnName("password");
            mb.Property(x => x.Birth).HasColumnName("birth");
            mb.Property(x => x.WalletId).HasColumnName("walletId");
        });
        
        modelBuilder.Entity<User>()
            .HasOne<Wallet>(x => x.Wallet)
            .WithOne()
            .HasForeignKey<Wallet>(x => x.UserId);
        modelBuilder.Entity<User>()
            .HasMany<Bet>(x => x.Bets)
            .WithOne()
            .HasForeignKey(x => x.UserId);
        modelBuilder.Entity<User>()
            .HasIndex(x => x.Email)
            .IsUnique();
        #endregion
        
        #region Wallet
        
        modelBuilder.Entity<Wallet>(mb =>
        {
            mb.ToTable("wallets");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
            mb.Property(x => x.Balance).HasColumnName("balance").HasColumnType("DECIMAL(7, 2)");
            mb.Property(x => x.UserId).HasColumnName("userId");
            mb.Property(x => x.CurrencyId).HasColumnName("currencyId");
        });
        
        modelBuilder.Entity<Wallet>()
            .HasMany<WalletTransaction>(x => x.Transactions)
            .WithOne()
            .HasForeignKey(x => x.WalletId);
        modelBuilder.Entity<Wallet>()
            .HasOne<Currency>(x => x.Currency)
            .WithMany()
            .HasForeignKey(x => x.CurrencyId);
        
        #endregion
        
        #region WalletTransaction
        
        modelBuilder.Entity<WalletTransaction>(mb =>
        {
            mb.ToTable("walletTransactions");
            mb.HasKey(x => x.Id);
            mb.Property(x => x.Name).HasColumnName("name").IsRequired();
            mb.Property(x => x.CreationDate).HasColumnName("creationDate");
            mb.Property(x => x.DeletedDate).HasColumnName("deletedDate");
            mb.Property(x => x.Amount).HasColumnName("amount").HasColumnType("DECIMAL(7, 2)");
            mb.Property(x => x.WalletId).HasColumnName("walletId");
            mb.Property(x => x.Operation).HasColumnName("operation");
        });
        
        #endregion
    }
}