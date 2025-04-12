using System;
using System.Collections.Generic;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public partial class DBLibraryContext : DbContext
    {
        public DBLibraryContext()
        {
        }

        public DBLibraryContext(DbContextOptionsBuilder builder)
        {
            var options = builder.Options;
            this.Database.EnsureCreated();
        }

        public DBLibraryContext(DbContextOptions<DBLibraryContext> options)
            : base(options)
        {
        }

        public DBLibraryContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Continent> Continents { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Footballer> Footballers { get; set; }

        public virtual DbSet<Footballerstrophy> Footballerstrophies { get; set; }

        public virtual DbSet<Stadium> Stadiums { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Trophy> Trophies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=127.0.0.1;Database=footballteams;User Id=root;Password=Maritsa_154;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Continent>(entity =>
            {
                entity.HasKey(e => e.ContinentCode).HasName("PRIMARY");

                entity.ToTable("continents");

                entity.Property(e => e.ContinentCode)
                    .HasMaxLength(2)
                    .IsFixedLength()
                    .HasColumnName("continent_code");
                entity.Property(e => e.ContinentName)
                    .HasMaxLength(50)
                    .HasColumnName("continent_name");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryCode).HasName("PRIMARY");

                entity.ToTable("countries");

                entity.HasIndex(e => e.ContinentCode, "FK_CountriesContinents");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsFixedLength()
                    .HasColumnName("country_code");
                entity.Property(e => e.ContinentCode)
                    .HasMaxLength(2)
                    .IsFixedLength()
                    .HasColumnName("continent_code");
                entity.Property(e => e.CountryName)
                    .HasMaxLength(30)
                    .HasColumnName("country_name");

                entity.HasOne(d => d.ContinentCodeNavigation).WithMany(p => p.Countries)
                    .HasForeignKey(d => d.ContinentCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CountriesContinents");
            });

            modelBuilder.Entity<Footballer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("footballers");

                entity.HasIndex(e => e.CountryCode, "FK_FootballersCountries");

                entity.HasIndex(e => e.TeamId, "FK_FootballersTeams");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Age).HasColumnName("age");
                entity.Property(e => e.Captain).HasColumnName("captain");
                entity.Property(e => e.CountryCode)
                    .HasMaxLength(30)
                    .HasColumnName("country_code");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .HasColumnName("first_name");
                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .HasColumnName("last_name");
                entity.Property(e => e.Price)
                    .HasPrecision(19)
                    .HasColumnName("price");
                entity.Property(e => e.Salary)
                    .HasPrecision(19)
                    .HasColumnName("salary");
                entity.Property(e => e.ShirtNumber).HasColumnName("shirt_number");
                entity.Property(e => e.TeamId).HasColumnName("team_id");
                entity.Property(e => e.TeamPosition)
                    .HasMaxLength(30)
                    .HasColumnName("team_position");
                entity.Property(e => e.Trophies).HasColumnName("trophies");

                entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.Footballers)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FootballersCountries");

                entity.HasOne(d => d.Team).WithMany(p => p.Footballers)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_FootballersTeams");
            });

            modelBuilder.Entity<Footballerstrophy>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("footballerstrophy");

                entity.HasIndex(e => e.TrophyId, "FK_Employees");

                entity.HasIndex(e => e.FootballerId, "FK_Programs");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.FootballerId).HasColumnName("footballer_id");
                entity.Property(e => e.TrophyId).HasColumnName("trophy_id");

                entity.HasOne(d => d.Footballer).WithMany(p => p.Footballerstrophies)
                    .HasForeignKey(d => d.FootballerId)
                    .HasConstraintName("FK_Programs");

                entity.HasOne(d => d.Trophy).WithMany(p => p.Footballerstrophies)
                    .HasForeignKey(d => d.TrophyId)
                    .HasConstraintName("FK_Employees");
            });

            modelBuilder.Entity<Stadium>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("stadium");

                entity.HasIndex(e => e.CountryCode, "FK_StadiumCountries");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Capacity).HasColumnName("capacity");
                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsFixedLength()
                    .HasColumnName("country_code");
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
                entity.Property(e => e.TownName)
                    .HasMaxLength(30)
                    .HasColumnName("town_name");

                entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.Stadium)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StadiumCountries");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("teams");

                entity.HasIndex(e => e.CountryCode, "FK_TeamsCountries");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CoachName)
                    .HasMaxLength(30)
                    .HasColumnName("coach_name");
                entity.Property(e => e.Colours)
                    .HasMaxLength(30)
                    .HasColumnName("colours");
                entity.Property(e => e.CountryCode)
                    .HasMaxLength(30)
                    .HasColumnName("country_code");
                entity.Property(e => e.Founded).HasColumnName("founded");
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
                entity.Property(e => e.TeamStadium)
                    .HasMaxLength(30)
                    .HasColumnName("team_stadium");

                entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.Teams)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamsCountries");
            });

            modelBuilder.Entity<Trophy>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("trophies");

                entity.HasIndex(e => e.ContinentCode, "FK_TrophiesContinents");

                entity.HasIndex(e => e.CountryCode, "FK_TrophiesCountries");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ContinentCode)
                    .HasMaxLength(30)
                    .HasColumnName("continent_code");
                entity.Property(e => e.CountryCode)
                    .HasMaxLength(30)
                    .HasColumnName("country_code");
                entity.Property(e => e.Footballers).HasColumnName("footballers");
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.HasOne(d => d.ContinentCodeNavigation).WithMany(p => p.Trophies)
                    .HasForeignKey(d => d.ContinentCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrophiesContinents");

                entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.Trophies)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrophiesCountries");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
