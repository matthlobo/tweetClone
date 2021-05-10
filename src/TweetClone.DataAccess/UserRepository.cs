using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetClone.DataAccess.Entities;

namespace TweetClone.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataAccessDbContext context;
        
        public UserRepository(IDataAccessDbContext context)
        {
            this.context = context;
        }
        public User GetById(Guid id)
        {
            return context.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Edit(User source)
        {
            var user = GetById(source.Id);

            if (user == null)
                throw new ArgumentException($"The user with id {user.Id} wasn't found");

            user.Name = source.Name;
            user.Email = source.Email;

            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = GetById(id);

            if (user == null)
                throw new ArgumentException($"The user with id {user.Id} wasn't found");

            context.Users.Remove(user);
            context.SaveChanges();

        }

        public User GetWithTweets(Guid id)
        {
            return context.Users.Include(x => x.Tweets).FirstOrDefault(u => u.Id == id);
        }

        public void AddTweet(Guid userId, Tweet tweetText)
        {
            if (tweetText == null)
                throw new ArgumentException($"The tweet is null");
            
            // Finding the user and adding the tweet to him
            var user = context.Users.Find(userId);
            user.Tweets.Add(tweetText);
            context.SaveChanges();
        }        

        public void DeleteTweet(Guid userId, Guid tweetId)
        {
            var user = this.GetWithTweets(userId);

            if (user == null)
                throw new ArgumentException($"The User with id {userId} wasn't found.");

            var tweet = user.Tweets.FirstOrDefault(x => x.Id == tweetId);

            if (tweet == null)
                throw new ArgumentException($"The tweet with id {tweetId} wasn't found");

            user.Tweets.Remove(tweet);
            context.SaveChanges();
        }

      
    }
}
