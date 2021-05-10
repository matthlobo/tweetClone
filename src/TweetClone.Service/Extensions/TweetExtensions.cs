using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetClone.DataAccess.Entities;
using TweetClone.Service.Requests;
using TweetClone.Service.Responses;

namespace TweetClone.Service.Extensions
{
    public static class TweetExtensions
    {
        public static IEnumerable<TweetResponse> ToResponse(this IEnumerable<Tweet> tweets)
        {
            if (tweets == null)
                return new List<TweetResponse>();

            return tweets.Select(ToResponse).ToList();
        }

        public static TweetResponse ToResponse(this Tweet tweet)
        {
            if (tweet == null)
                return null;

            return new TweetResponse
            {
                Id = tweet.Id,
                TweetText = tweet.TweetText,                
            };
        }

        public static Tweet ToEntity(this TweetRequest tweet)
        {
            if (tweet == null)
                return null;

            return new Tweet
            {
                TweetText = tweet.TweetText                               
            };
        }
    }
}
