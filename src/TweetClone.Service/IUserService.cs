using System;
using TweetClone.Service.Responses;
using TweetClone.Service.Requests;
using System.Collections.Generic;


namespace TweetClone.Service
{
    public interface IUserService
    {
        UserResponse GetById(Guid id);
        IEnumerable<UserResponse> GetAll();
        UserResponse Add(UserRequest request);
        UserResponse Edit(UserRequest request);
        void Delete(Guid id);
        IEnumerable<TweetResponse> GetTweets(Guid userId);
        TweetResponse GetOneTweet(Guid userId, Guid tweetId);
        TweetResponse AddTweet(Guid userId, TweetRequest request);
        void DeleteTweet(Guid userId, Guid tweetId);

    }
}
