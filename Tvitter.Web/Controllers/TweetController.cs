using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tvitter.Core.Entity.Enum;
using Tvitter.Core.Service;
using Tvitter.Model.Entities;
using Tvitter.Web.Models;

namespace Tvitter.Web.Controllers
{
    public class TweetController : Controller
    {
        private readonly ITweetService<Tweet> _tweetContext;
        private readonly ITagService<Tag> _tagContext;
        private readonly ICoreService<User> _userContext;
        private IWebHostEnvironment _environment;


        public TweetController(ITweetService<Tweet> tweetContext, ICoreService<User> userContext,
            IWebHostEnvironment environment, ITagService<Tag> tagContext)
        {
            _tweetContext = tweetContext;
            _userContext = userContext;
            _environment = environment;
            _tagContext = tagContext;

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

            return View(_tag);
        }

        [HttpPost]
        public IActionResult PostTweet(Tweet tweet)
        {
            Guid id = Guid.Parse(User.FindFirst("ID").Value);

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
                _tweetContext.Add(tweet);
            }
            return RedirectToAction("Index", "Tweet", new { id = tweet.Parent.ToString() });
        }
    }
}
