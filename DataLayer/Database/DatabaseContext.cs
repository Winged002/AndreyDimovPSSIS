using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {

        public DbSet<DatabaseUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source = {databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

            //Create a user
            var user = new DatabaseUser()
            {
                Id = 1,
                Names = "John Doe",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10)
            };

            var studentUser = new DatabaseUser()
            {
                Id = 2,
                Names = "Andrej Dimov",
                Password = "andrej123",
                Role = UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddYears(10)
            };

            var studentUser2 = new DatabaseUser()
            {
                Id = 3,
                Names = "Allena",
                Password = "13223",
                Role = UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddYears(15)
            };

            var teacherUser = new DatabaseUser()
            {
                Id = 4,
                Names = "Mila",
                Password = "14523",
                Role = UserRolesEnum.PROFESSOR,
                Expires = DateTime.Now.AddYears(5)
            };

            var adminUser = new DatabaseUser()
            {
                Id = 5,
                Names = "Jessy",
                Password = "1432223",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(7)
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user);

        }
    }
}
