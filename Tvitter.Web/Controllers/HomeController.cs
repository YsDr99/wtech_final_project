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
        private readonly ICoreService<User> _Usercontext;
        private readonly ICoreService<Follow> _followContext;
        private readonly ICoreService<Tweet> _tweetContext;
        private IWebHostEnvironment _environment;
        public HomeController(ILogger<HomeController> logger, ICoreService<User> context,
            ICoreService<Follow> followContext, ICoreService<Tweet> tweetContext, IWebHostEnvironment environment)
        {
            _logger = logger;
            _Usercontext = context;
            _followContext = followContext;
            _tweetContext = tweetContext;
            _environment = environment;
        }

        public IActionResult Index()
        {
            Guid id = Guid.Parse(User.FindFirst("ID").Value);
            var user = _Usercontext.GetById(id);
            user.Tweets = _tweetContext.GetDefault(x => x.UserId == user.ID);
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

                            tweet.MediaUrl= upload.UploadFile();
                        }
                    }
                }
                _tweetContext.Add(tweet);
            }
            return RedirectToAction("Index", "Home");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
