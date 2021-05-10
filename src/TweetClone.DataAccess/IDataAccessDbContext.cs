using Microsoft.EntityFrameworkCore;
using TweetClone.DataAccess.Entities;

namespace TweetClone.DataAccess
{
    public interface IDataAccessDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Tweet> Tweets { get; set; }
        int SaveChanges();
    }
}
