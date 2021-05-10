using System;
using System.Collections.Generic;
using System.Text;

namespace TweetClone.Service.Requests
{
    public class TweetRequest
    {
        public Guid Id { get; set; }
        public string TweetText { get; set; }
    }
}
