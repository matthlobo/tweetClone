using Microsoft.EntityFrameworkCore;
using TweetClone.DataAccess;
using TweetClone.DataAccess.Entities;

namespace TweetClone
{
    public class ApiDbContext : DbContext, IDataAccessDbContext
    {
        public ApiDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
    }
}
