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

namespace Tvitter.Web.Controllers
{
    [Authorize]
    public class TweetController : Controller
    {
        private readonly ITweetService<Tweet> _tweetContext;
        private readonly ITagService<Tag> _tagContext;
        private readonly ICoreService<User> _userContext;
        private readonly ICoreService<Mention> _mentionContext;
        private IWebHostEnvironment _environment;


        public TweetController(ITweetService<Tweet> tweetContext, ICoreService<User> userContext,
            IWebHostEnvironment environment, ITagService<Tag> tagContext, ICoreService<Mention> mentionContext)
        {
            _tweetContext = tweetContext;
            _userContext = userContext;
            _environment = environment;
            _tagContext = tagContext;
            _mentionContext = mentionContext;

        }

        public IActionResult Index(string id)
        {
            Tweet tweet = _tweetContext.GetTweet(Guid.Parse(id));
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

            if (ModelState.IsValid)
            {
                tweet.UserId = id;
                tweet.Type = TweetType.comment;
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

                var input = tweet.Text;

                var regex = new Regex(@"#\w+");
                var matches = regex.Matches(input);

                var regexMention = new Regex(@"@\w+");
                var matchesMention = regexMention.Matches(input);

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
                        _tweetContext.Add(tweet);

                        if (lastAddedTweetId == Guid.Empty)
                        {
                            lastAddedTweetId = tweet.ID;

                        }

                        tweet.ID = Guid.Empty;
                        tweet.Type = TweetType.tagCopy;
                    }
                }
                else
                {
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
                            _mentionContext.Add(mention1);
                        }
                    }
                }

            }
            return RedirectToAction("Index", "Tweet", new { id = tweet.Parent.ToString() });
        }
    }
}
