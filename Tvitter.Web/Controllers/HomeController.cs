using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tvitter.Core.Service;
using Tvitter.Model.Entities;
using Tvitter.Web.Models;

namespace Tvitter.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICoreService<User> _userContext;
        private readonly ICoreService<Follow> _followContext;
        private readonly ICoreService<Tweet> _tweetContext;
        private readonly ICoreService<Like> _likeContext;
        private IWebHostEnvironment _environment;
        public HomeController(ILogger<HomeController> logger, ICoreService<User> context,
            ICoreService<Follow> followContext, ICoreService<Tweet> tweetContext, IWebHostEnvironment environment,
            ICoreService<Like> likeContext)
        {
            _logger = logger;
            _userContext = context;
            _followContext = followContext;
            _tweetContext = tweetContext;
            _environment = environment;
            _likeContext = likeContext;
        }


        public IActionResult Index()
        {
            Guid id = Guid.Parse(User.FindFirst("ID").Value);
            var user = _userContext.GetById(id);

            var query = from u in _userContext.GetAll()
                        join f in _followContext.GetDefault(x => x.FollowerId == id)
                            on u.ID equals f.FollowingId
                        join t in _tweetContext.GetAll()
                            on u.ID equals t.UserId
                        orderby t.CreatedDate descending
                        select Tuple.Create<User, Tweet>(u, t);
            user.HomePageTweets = query.ToList();
            foreach(var item in user.HomePageTweets)
            {
                item.Item2.Likes = _likeContext.GetDefault(x => x.TweetId == item.Item2.ID);
            }
            return View(Tuple.Create(user, new Tweet()));

        }

        [HttpPost]
        public IActionResult Index(Tweet tweet)
        {
            Guid id = Guid.Parse(User.FindFirst("ID").Value);

            if (ModelState.IsValid)
            {
                tweet.UserId = id;
                if (HttpContext.Request.Form.Files != null)
                {
                    var files = HttpContext.Request.Form.Files;

                    foreach (var file in files)
                    {
                        if (file.Length > 0 && file.ContentType.Contains("image"))
                        {
                            Upload upload = new Upload(file, "TweetMedia", _environment);

                            tweet.MediaUrl = upload.UploadFile();
                        }
                    }
                }
                _tweetContext.Add(tweet);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult LikeTweet(string UserID, string TweetId)
        {
            Like like = new Like();
            like.UserId = Guid.Parse(UserID);
            like.TweetId = Guid.Parse(TweetId);
            _likeContext.Add(like);
            

            Tweet tweet = _tweetContext.GetFirstOrDefault(x => x.ID == Guid.Parse(TweetId));
            tweet.Likes = _likeContext.GetDefault(x => x.TweetId == Guid.Parse(TweetId));

            User user = _userContext.GetById(tweet.UserId);

            return PartialView("PartialView/_DisplayTweet", Tuple.Create<User, Tweet>(user, tweet));
           
        }

        [HttpPost]
        public IActionResult UnlikeTweet(string UserID, string TweetId)
        {
            Like like = _likeContext.GetFirstOrDefault(x => x.TweetId == Guid.Parse(TweetId) && x.UserId == Guid.Parse(UserID));
            _likeContext.RemovePerma(like);

            Tweet tweet = _tweetContext.GetFirstOrDefault(x => x.ID == Guid.Parse(TweetId));
            tweet.Likes = _likeContext.GetDefault(x => x.TweetId == Guid.Parse(TweetId));

            User user = _userContext.GetById(tweet.UserId);

            return PartialView("PartialView/_DisplayTweet", Tuple.Create<User, Tweet>(user, tweet));

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
