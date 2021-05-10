using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TweetClone.Service.Requests
{
    public class UserRequest
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The input {0} is required!")]
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
