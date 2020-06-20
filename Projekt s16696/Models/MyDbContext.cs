using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_s16696.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Building> Buildings { get; set; }


        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Banner>(opt =>
            {
                opt.HasKey(p => p.IdAdvertisement);
                opt.Property(p => p.IdAdvertisement).ValueGeneratedOnAdd();
                opt.Property(p => p.Name).IsRequired();
                opt.Property(p => p.Price).HasColumnType("decimal(6,2)");
                opt.Property(p => p.Area).HasColumnType("decimal(6,2)");
                opt.HasOne(p => p.Campaign).WithMany(p => p.Banners).HasForeignKey(p => p.IdCampaign);

            });

            builder.Entity<Building>(opt =>
            {
                opt.HasKey(p => p.IdBuilding);
                opt.Property(p => p.IdBuilding).ValueGeneratedOnAdd();
                opt.Property(p => p.Street).IsRequired();
                opt.Property(p => p.City).IsRequired();
                opt.Property(p => p.Height).HasColumnType("decimal(6,2)");
                opt.Ignore(p => p.Campaings);
            });



            builder.Entity<Campaign>(opt =>
            {
                opt.HasKey(p => p.IdCampaign);
                opt.Property(p => p.IdCampaign).ValueGeneratedOnAdd();
                opt.Property(p => p.PricePerSquareMeter)
                .HasColumnType("decimal(6,2)");
                opt.Property(p => p.Building_1).IsRequired();
                opt.Property(p => p.Building_2).IsRequired();

                opt.Ignore(p => p.Building_1);
                opt.Ignore(p => p.Building_2);


                opt.HasOne(p => p.Building_1)
                .WithMany(p => p.FromIdBuild).HasForeignKey(p => p.FromIdBuilding);

                opt.HasOne(p => p.Building_2)
                .WithMany(p => p.ToIdBuild).HasForeignKey(p => p.ToIdBuilding);

                opt.HasMany(p => p.Banners)
                    .WithOne(p => p.Campaign)
                    .HasForeignKey(p => p.IdCampaign);

            });


            builder.Entity<Client>(opt =>
            {
                opt.HasKey(p => p.IdClient);
                opt.Property(p => p.IdClient).ValueGeneratedOnAdd();
                opt.Property(p => p.Login).IsRequired();

                opt.HasMany(p => p.Campaigns)
                       .WithOne(p => p.Client)
                       .HasForeignKey(p => p.IdClient)
                       .IsRequired();

            });

        }
    }
}
