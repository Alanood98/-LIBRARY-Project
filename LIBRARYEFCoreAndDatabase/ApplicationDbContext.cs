using Microsoft.EntityFrameworkCore;
using LIBRARYEFCoreAndDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARYEFCoreAndDatabase
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer(" Data Source=(local); Initial Catalog=LibraryDB; Integrated Security=true; TrustServerCertificate=True ");
        }


        public DbSet<Book> Bookes { get; set; }
        public DbSet<Admin> Admines { get; set; }
        public DbSet<User> Useres { get; set; }
        public DbSet<Category> Categoryes { get; set; }
        public DbSet<BorrowingBook> BorrowingBookes { get; set; }
        

    }
}
