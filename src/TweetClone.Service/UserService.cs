using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetClone.DataAccess;
using TweetClone.Service.Extensions;
using TweetClone.Service.Requests;
using TweetClone.Service.Responses;

namespace TweetClone.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<UserResponse> GetAll()
        {
            var users = userRepository.GetAll();
            return users.Select(x => x.ToResponse()).ToList();
        }

        public UserResponse GetById(Guid id)
        {
            var user = userRepository.GetById(id);
            return user.ToResponse();
        }

        public UserResponse Add(UserRequest request)
        {
            var user = request.ToEntity();
            userRepository.Add(user);
            
            return user.ToResponse();
        }       

        public UserResponse Edit(UserRequest request)
        {
            var user = request.ToEntity();
            userRepository.Edit(user);
            
            return user.ToResponse();
        }

        public void Delete(Guid id)
        {
            userRepository.Delete(id);
        }

        public TweetResponse GetOneTweet(Guid userId, Guid tweetId)
        {
            var user = userRepository.GetWithTweets(userId);

            if (user == null)
                throw new ArgumentException($"The User with id {userId} wasn't found.");

            var tweet = user.Tweets.FirstOrDefault(x => x.Id == tweetId);
            
            return tweet.ToResponse();
        }

        public IEnumerable<TweetResponse> GetTweets(Guid userId)
        {
            var user = userRepository.GetWithTweets(userId);

            if (user == null)
                throw new ArgumentException($"The user with Id {userId} wasn't found.");

            return user.Tweets.ToResponse();
        }
        public TweetResponse AddTweet(Guid userId, TweetRequest request)
        {
            var user = userRepository.GetById(userId);

            if(user == null)
                throw new ArgumentException($"The user with Id {userId} wasn't found.");

            var tweet = request.ToEntity();
            userRepository.AddTweet(userId, tweet);
            return tweet.ToResponse();
        }

        public void DeleteTweet(Guid userId, Guid tweetId)
        {
            throw new NotImplementedException();
        }
    }
}
