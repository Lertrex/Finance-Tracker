using Finance_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance_Tracker
{
    class AppDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\svl75\source\repos\Finance Tracker\Finance Tracker\DataBase.mdf;Integrated Security=True;");
        }
    }
}
