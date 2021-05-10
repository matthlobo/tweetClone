using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TweetClone.DataAccess.Entities
{
    public class Tweet
    {
        [Key]
        public Guid Id { get; set; }
        public string TweetText { get; set; }
    }
}
