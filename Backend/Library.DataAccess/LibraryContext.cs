using System;
using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Library.DataAccess
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class LibraryContext: DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User_Organization> user_Organizations { get; set; } 
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        public DbSet<Session> Sessions {get;set;}

        //public DbSet<Session> Sessions {get;set;}

        public LibraryContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public LibraryContext(DbContextOptions options) : base(options) { }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                if (!optionsBuilder.IsConfigured)
                {
                    string directory = Directory.GetCurrentDirectory();

                    IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(directory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                    var connectionString = configuration.GetConnectionString(@"LibraryDB");
                    optionsBuilder.UseSqlServer(connectionString);
                 }
        }


    }
}