using System;
using System.Collections.Generic;
using System.Text;

namespace TweetClone.Service.Responses
{
    public class TweetResponse
    {
        public Guid Id { get; set; }
        public string TweetText { get; set; }
    }
}
