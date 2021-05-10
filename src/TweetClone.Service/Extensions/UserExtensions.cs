using System;
using System.Collections.Generic;
using System.Text;
using TweetClone.DataAccess.Entities;
using TweetClone.Service.Requests;
using TweetClone.Service.Responses;

namespace TweetClone.Service.Extensions
{
    public static class UserExtensions
    {
        public static UserResponse ToResponse(this User user)
        {
            if (user == null)
                return null;

            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        public static User ToEntity(this UserRequest user)
        {
            if (user == null)
                return null;

            return new User
            {
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email                
            };
        }
    }
}
