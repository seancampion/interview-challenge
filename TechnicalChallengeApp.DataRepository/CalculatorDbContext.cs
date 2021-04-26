using Microsoft.EntityFrameworkCore;
using TechnicalChallengeApp.DataRepository.Table;

namespace TechnicalChallengeApp.DataRepository
{
    /// <summary>
    /// <para>
    /// Our SQLite database! Great information on how to use
    /// SQLite can be found at the following site:
    /// https://entityframeworkcore.com/providers-sqlite
    /// </para>
    ///
    /// <para>
    /// If you run into issues with migrations when making changes to
    /// tables (modifying or adding), make sure you have the Entity
    /// Framework Core Package Manager Console tools installed:
    /// (Package Manager) - Install-Package Microsoft.EntityFrameworkCore.Tools
    /// </para>
    /// </summary>
    public class CalculatorDbContext : DbContext
    {
        /// <summary>
        /// dbo.SessionData - where we store data relevant to the user's session
        /// </summary>
        public DbSet<SessionData> SessionData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Database/CalculatorDb.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SessionData>().ToTable("SessionData");
        }
    }
}