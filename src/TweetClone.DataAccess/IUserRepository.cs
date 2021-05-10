using System;
using System.Collections.Generic;
using TweetClone.DataAccess.Entities;

namespace TweetClone.DataAccess
{
    public interface IUserRepository
    {
        User GetById(Guid id);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Edit(User user);        
        User GetWithTweets(Guid id);
        void Delete(Guid id);
        void AddTweet(Guid userId, Tweet tweetText);
        void DeleteTweet(Guid userId, Guid tweetId);
    }
}