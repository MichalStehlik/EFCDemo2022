using EFCDemo2022.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCDemo2022.Data
{
    internal class ApplicationDbContext : DbContext
    {
        private string _connectionString = String.Empty;

        public DbSet<Company> Companies { get; set; }
        public DbSet<Game> Games { get; set; }

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseSqlite(_connectionString);
            builder.LogTo(Console.WriteLine, new[] 
            { 
                //CoreEventId.ContextInitialized,
                RelationalEventId.CommandExecuted
            });
            builder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            Company cdp = new Company { CompanyId = 1, Name = "CD Projekt" };
            builder.Entity<Company>().HasData(cdp);
            builder.Entity<Company>().HasData(new Company { CompanyId = 2, Name = "id Software" });
            builder.Entity<Company>().HasData(new Company { CompanyId = 3, Name = "Bethesda Softworks" });
            builder.Entity<Game>().HasData(new Game { GameId = 1, Name = "Cyberpunk 2077", DeveloperId = 1 });
            builder.Entity<Game>().HasData(new Game { GameId = 2, Name = "Witcher: Wild Hunt", DeveloperId = 1 });
            builder.Entity<Game>().HasData(new Game { GameId = 3, Name = "Starfield", DeveloperId = 3 });
        }
    }
}
