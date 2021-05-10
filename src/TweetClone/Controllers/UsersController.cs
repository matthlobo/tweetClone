using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetClone.Service;
using TweetClone.Service.Requests;

namespace TweetClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        // GET: UsersController/GetById/5
        [HttpGet("{userId}")]
        public ActionResult GetById(Guid userId)
        {
            return Ok(service.GetById(userId));
        }

        [HttpPost]
        public ActionResult Add([FromBody] UserRequest request)
        {
            if(!ModelState.IsValid)            
                return BadRequest(ModelState);
            
            return Ok(service.Add(request));
        }

        // POST: UsersController/Create
        [HttpPut("{userId}")]        
        public ActionResult Edit([FromRoute] Guid userId, [FromBody] UserRequest request)
        {
            request.Id = userId;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(service.Edit(request));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{userId}")]
        public IActionResult Delete([FromRoute] Guid userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Delete(userId);
            return Ok();
        }

        [HttpGet("{userId}/tweets")]
        public IActionResult GetTweets([FromRoute] Guid userId)
        {
            return Ok(service.GetTweets(userId));
        }

        [HttpGet("{userId}/tweets/{tweetId}")]
        public IActionResult GetTweetById([FromRoute] Guid userId, [FromRoute] Guid tweetId)
        {
            return Ok(service.GetOneTweet(userId, tweetId));
        }

        [HttpPost("{userId}/tweets")]
        public IActionResult PostTweet([FromRoute] Guid userId, [FromBody] TweetRequest request)
        {
            var tweet = service.AddTweet(userId, request);
            return CreatedAtAction(nameof(GetTweetById), new { userId = userId, tweetId = tweet.Id }, tweet);
        }               

        [HttpDelete("{userId}/tweets/{tweetId}")]
        public IActionResult DeleteTweet([FromRoute] Guid userId, [FromRoute] Guid tweetId)
        {
            service.DeleteTweet(userId, tweetId);
            return Ok();
        }
    }
}
