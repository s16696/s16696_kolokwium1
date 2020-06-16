using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_2.Models
{
    public class MyDbContext :DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player_Team> Player_Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Championship_Team> Championship_Teams { get; set; }
        public MyDbContext()
        {

        }


        public MyDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Championship>(opt =>
            {
                opt.HasKey(e => e.IdChampionship);
                opt.Property(e => e.IdChampionship).ValueGeneratedOnAdd();

                opt.Property(e => e.OfficialName).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Championship_Team>(opt =>
            {
                opt.HasKey(e => e.IdChampionship);
                opt.HasKey(e => e.IdTeam);
                opt.HasOne(e => e.Team)
                .WithMany(e => e.Championship_Teams)
                .HasForeignKey(e => e.IdTeam);

                opt.HasOne(e => e.Championship)
                .WithMany(e => e.Championship_Teams)
                .HasForeignKey(e => e.IdChampionship);
            });

            modelBuilder.Entity<Team>(opt =>
            {
                opt.HasKey(e => e.IdTeam);
                opt.Property(e => e.IdTeam).ValueGeneratedOnAdd();

                opt.Property(e => e.TeamName).HasMaxLength(30);
            });

            modelBuilder.Entity<Player>(opt =>
            {
                opt.HasKey(e => e.IdPlayer);
                opt.Property(e => e.IdPlayer).ValueGeneratedOnAdd();
                opt.Property(e => e.FirstName).HasMaxLength(30);
                opt.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Player_Team>(opt =>
            {
                opt.HasKey(e => e.IdPlayer);
                opt.HasKey(e => e.IdTeam);
                opt.HasOne(e => e.Team).WithMany(e => e.Player_teams)
                .HasForeignKey(e => e.IdTeam);



                opt.HasOne(e => e.Player).WithMany(e => e.Player_Teams).HasForeignKey(e => e.IdPlayer);

                opt.Property(e => e.Comment).HasMaxLength(300).IsRequired();
            });


        }
    }
}
