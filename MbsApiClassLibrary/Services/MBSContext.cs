using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBStest03.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MBS_API
{
    public class MBSContext : DbContext
    {
        public DbSet<Day> Days { get; set; }
        public DbSet<Influence> Influences { get; set; }
        public DbSet<Mood> Moods { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        public static readonly ILoggerFactory ConsoleLoggerFactory =
            LoggerFactory.Create(builder =>
            {
                builder
                        .AddFilter((category, level) =>
                            category == DbLoggerCategory.Database.Command.Name
                            && level == LogLevel.Information);
                        //.AddConsole();
            });

        public MBSContext(DbContextOptions<MBSContext> options) : base(options)
        {

        }

        public MBSContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); //I et ASP.NET Core projekt fås denne gennem Microsoft.AspNetCore.App,
            //string _connectionString = config.GetConnectionString("MBSDB");                           //men ved et tomt projekt skal referencen Microsoft.Extensions.Configuration.Json medtages.
            optionsBuilder.UseSqlServer(config.GetConnectionString("MBSDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }
        //modelBuilder.Entity<Day>()
        //        .Property(d => d.MoodName)
        //        .HasConversion<int>();

        //    modelBuilder.Entity<Day>()
        //        .Property(d => d.InfluenceName)
        //        .HasConversion<int>();
    }
}
