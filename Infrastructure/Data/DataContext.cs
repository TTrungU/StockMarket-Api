using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WatchList>()
                .HasKey(wl => new { wl.StockId, wl.UserId });
            modelBuilder.Entity<WatchList>()
                .HasOne(wl => wl.Stock)
                .WithMany(s => s.WatchLists)
                .HasForeignKey(wl => wl.StockId);
            modelBuilder.Entity<WatchList>()
                .HasOne(wl => wl.User)
                .WithMany(u => u.WatchLists)
                .HasForeignKey(wl => wl.UserId);

            modelBuilder.Entity<Notification>()
                .HasOne(e => e.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<StockPrice>()
               .HasOne(e => e.Stock)
               .WithMany(u => u.StockPrices)
               .HasForeignKey(e => e.StockId);

        }
    }
}
