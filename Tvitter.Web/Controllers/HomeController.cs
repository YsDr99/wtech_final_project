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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tvitter.Core.Entity.Enum;
using Tvitter.Core.Service;
using Tvitter.Model.Entities;
using Tvitter.Web.Models;
using Tvitter.Web.Utility;

namespace Tvitter.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICoreService<User> _userContext;
        private readonly ICoreService<Follow> _followContext;
        private readonly ITweetService<Tweet> _tweetContext;
        private readonly ICoreService<Like> _likeContext;
        private readonly ITagService<Tag> _tagContext;
        private readonly ICoreService<Mention> _mentionContext;
        private readonly ICoreService<Notification> _notificationContext;

        private IWebHostEnvironment _environment;
        public HomeController(ILogger<HomeController> logger, ICoreService<User> context,
            ICoreService<Follow> followContext, ITweetService<Tweet> tweetContext, IWebHostEnvironment environment,
            ICoreService<Like> likeContext, ITagService<Tag> tagContext, ICoreService<Mention> mentionContext,
            ICoreService<Notification> notificationContext)
        {
            _logger = logger;
            _userContext = context;
            _followContext = followContext;
            _tweetContext = tweetContext;
            _environment = environment;
            _likeContext = likeContext;
            _tagContext = tagContext;
            _mentionContext = mentionContext;
            _notificationContext = notificationContext;

        }


        public IActionResult Index()
        {
            Guid id = Guid.Parse(User.FindFirst("ID").Value);
            var user = _userContext.GetById(id);

            var query = from u in _userContext.GetAll()
                        join f in _followContext.GetDefault(x => x.FollowerId == id)
                            on u.ID equals f.FollowingId
                        join t in _tweetContext.GetTweets(x => x.Type == TweetType.Tweet)
                            on u.ID equals t.UserId
                        select Tuple.Create<User, Tweet>(u, t);

            var query2 = from u in _userContext.GetDefault(x => x.ID == id)
                         join t in _tweetContext.GetTweets(x => x.Type == TweetType.Tweet)
                             on u.ID equals t.UserId
                         select Tuple.Create<User, Tweet>(u, t);

            var result = query.Union(query2);
            user.HomePageTweets = result.ToList().OrderByDescending(x => x.Item2.CreatedDate).ToList();
            user.Notifications = _notificationContext.GetDefault(x => x.UserId == user.ID);

            var ActiveNotifications = _notificationContext.GetDefault(x => x.Status == Status.Active && x.UserId == user.ID).ToList();
            TempData["NewNotificationCount"] = ActiveNotifications.Count > 0 ? ActiveNotifications.Count.ToString() : "";

            return View(Tuple.Create(user, new Tweet()));

        }

        public IActionResult NameNotFound()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostTweet(Tweet tweet)
        {
            Guid id = Guid.Parse(User.FindFirst("ID").Value);
            Guid lastAddedTweetId = Guid.Empty;
            var clientIpAdress = HttpContext.GetRemoteIPAddress().ToString();

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

                tweet.Text = tweet.Text ?? ".";
                var input = tweet.Text;

                var regex = new Regex(@"#\w+");
                var matches = regex.Matches(input).OfType<Match>()
                                     .Select(m => m.Groups[0].Value)
                                     .Distinct().ToList();

                var regexMention = new Regex(@"@\w+");
                var matchesMention = regexMention.Matches(input).OfType<Match>()
                                     .Select(m => m.Groups[0].Value)
                                     .Distinct().ToList();


                if (matches.Count > 0)
                {
                    foreach (var match in matches)
                    {
                        string tagName = match.ToString().ToLower();
                        Tag tag = new Tag();
                        if (!_tagContext.Any(x => x.Name == tagName))
                        {
                            tag.Name = tagName;
                            _tagContext.Add(tag);
                        }
                    }

                    List<Tag> tags = _tagContext.GetAll().ToList();
                    foreach (var match in matches)
                    {
                        string tagName = match.ToString().ToLower();
                        Tag tag = new Tag();

                        tag = tags.FirstOrDefault(x => x.Name == tagName);
                        tweet.TagId = tag.ID;
                        tweet.CreatedIP = clientIpAdress;
                        _tweetContext.Add(tweet);

                        if (lastAddedTweetId == Guid.Empty)
                        {
                            lastAddedTweetId = tweet.ID;

                        }

                        tweet.ID = Guid.Empty;
                        tweet.Type = TweetType.TagCopy;
                    }
                }
                else
                {
                    tweet.CreatedIP = clientIpAdress;
                    _tweetContext.Add(tweet);
                    lastAddedTweetId = tweet.ID;
                }

                if (matchesMention.Count > 0)
                {

                    foreach (var mention in matchesMention)
                    {
                        var username = mention.ToString().Substring(1);
                        var user = _userContext.GetFirstOrDefault(x => x.Username == username);
                        if (user != null)
                        {
                            Mention mention1 = new Mention() { UserId = user.ID, TweetId = lastAddedTweetId };
                            Notification notification = new Notification()
                            {
                                UserId = user.ID,
                                Status = Status.Active,
                                Content = "You are mentioned at this ",
                                TweetId = lastAddedTweetId,
                                Type = NotificationType.Mention
                            };
                            _mentionContext.Add(mention1);
                            _notificationContext.Add(notification);
                        }
                    }
                }

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


            Tweet tweet = _tweetContext.GetTweet(x => x.ID == Guid.Parse(TweetId));

            User user = _userContext.GetById(tweet.UserId);

            return PartialView("PartialView/_DisplayTweet", Tuple.Create<User, Tweet>(user, tweet));

        }

        [HttpPost]
        public IActionResult UnlikeTweet(string UserID, string TweetId)
        {
            Like like = _likeContext.GetFirstOrDefault(x => x.TweetId == Guid.Parse(TweetId) && x.UserId == Guid.Parse(UserID));
            _likeContext.RemovePerma(like);

            Tweet tweet = _tweetContext.GetTweet(x => x.ID == Guid.Parse(TweetId));

            User user = _userContext.GetById(tweet.UserId);

            return PartialView("PartialView/_DisplayTweet", Tuple.Create<User, Tweet>(user, tweet));

        }

        public IActionResult Discover()
        {
            IEnumerable<Tuple<string, int>> trends = _tagContext.GetTrends().ToList();
            return View(trends);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
