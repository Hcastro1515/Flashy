using Flashy.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashy.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Flashcard> Flashcards => Set<Flashcard>(); 
        public DbSet<Flashset> Flashsets => Set<Flashset>(); 
    }
}
