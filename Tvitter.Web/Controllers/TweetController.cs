using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class TweetController : Controller
    {
        private readonly ITweetService<Tweet> _tweetContext;
        private readonly ITagService<Tag> _tagContext;
        private readonly ICoreService<User> _userContext;
        private readonly ICoreService<Mention> _mentionContext;
        private readonly ICoreService<Notification> _notificationContext;
        private IWebHostEnvironment _environment;


        public TweetController(ITweetService<Tweet> tweetContext, ICoreService<User> userContext,
            IWebHostEnvironment environment, ITagService<Tag> tagContext, ICoreService<Mention> mentionContext,
            ICoreService<Notification> notificationContext)
        {
            _tweetContext = tweetContext;
            _userContext = userContext;
            _environment = environment;
            _tagContext = tagContext;
            _mentionContext = mentionContext;
            _notificationContext = notificationContext;

        }

        public IActionResult Index(string id)
        {
            if (!Guid.TryParse(id, out Guid tweetID))
            {
                TempData["NotFoundName"] = "tweet";
                return RedirectToAction("NameNotFound", "Home");
            }

            Tweet tweet = _tweetContext.GetTweet(tweetID);
            if(tweet == null)
            {
                TempData["NotFoundName"] = "tweet";
                return RedirectToAction("NameNotFound", "Home");
            }

            tweet.User = _userContext.GetById(tweet.UserId);
            tweet.Parent = tweet.ID;
            return View(Tuple.Create(tweet.User,tweet));
        }

        public IActionResult Trend(string tag)
        {
            tag = tag.ToLower();
            Tag _tag = _tagContext.GetTag(x => x.Name == tag);
            if(_tag == null)
            {
                TempData["NotFoundName"] = tag;
                return RedirectToAction("NameNotFound", "Home");
            }

            return View(_tag);
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
                tweet.Type = TweetType.Comment;
                tweet.BelongsTo = tweet.Parent;
                tweet.ID = Guid.Empty;
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
                var matches = regex.Matches(input).Distinct().OfType<Match>()
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
            return RedirectToAction("Index", "Tweet", new { id = tweet.Parent.ToString() });
        }

        public IActionResult Retweet(string id)
        {
            if (!Guid.TryParse(id, out Guid tweetID))
            {
                TempData["NotFoundName"] = "tweet";
                return RedirectToAction("NameNotFound", "Home");
            }

            Tweet tweet = _tweetContext.GetTweet(tweetID);
            if (tweet == null)
            {
                TempData["NotFoundName"] = "tweet";
                return RedirectToAction("NameNotFound", "Home");
            }

            tweet.User = _userContext.GetById(tweet.UserId);
            tweet.RetweetId = tweet.ID;
            return View(Tuple.Create(tweet.User, tweet));
        }

        [HttpPost]
        public IActionResult Retweet(Tweet tweet)
        {
            Guid id = Guid.Parse(User.FindFirst("ID").Value);
            Guid lastAddedTweetId = Guid.Empty;
            var clientIpAdress = HttpContext.GetRemoteIPAddress().ToString();

            if (ModelState.IsValid)
            {
                tweet.UserId = id;
                tweet.ID = Guid.Empty;


                tweet.Text = tweet.Text ?? ".";
                var input = tweet.Text;

                var regex = new Regex(@"#\w+");
                var matches = regex.Matches(input).Distinct().OfType<Match>()
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
    }
}
