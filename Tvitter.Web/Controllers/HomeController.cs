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
        private readonly ICoreService<User> _context;
        private readonly ICoreService<Follow> _followContext;
        private readonly ICoreService<Tweet> _tweetContext;
        private IWebHostEnvironment _environment;
        public HomeController(ILogger<HomeController> logger, ICoreService<User> context,
            ICoreService<Follow> followContext, ICoreService<Tweet> tweetContext, IWebHostEnvironment environment)
        {
            _logger = logger;
            _context = context;
            _followContext = followContext;
            _tweetContext = tweetContext;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            Guid id = Guid.Parse(User.FindFirst("ID").Value);
            var user = _context.GetById(id);
            user.Followers = _followContext.GetDefault(x => x.FollowingId == user.ID);
            user.Following = _followContext.GetDefault(x => x.FollowerId == user.ID);
            user.Tweets = _tweetContext.GetDefault(x => x.UserId == user.ID);
            return View(user);
        }

        public IActionResult EditProfile()
        {
            Guid id = Guid.Parse(User.FindFirst("ID").Value);
            return View(_context.GetById(id));
        }

        [HttpPost]
        public IActionResult EditProfile(User user)
        {
            var updateUser = _context.GetById(user.ID);
            updateUser.Fullname = user.Fullname;
            updateUser.About = user.About;
            updateUser.Location = user.Location;
            updateUser.Website = user.Website;
            updateUser.BirthDate = user.BirthDate;
            updateUser.gender = user.gender;
            var newFileName = string.Empty;

            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = HttpContext.Request.Form.Files;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        //Getting FileName
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var FileExtension = Path.GetExtension(fileName);

                        // concating  FileName + FileExtension
                        newFileName = myUniqueFileName + FileExtension;

                        // Combines two strings into a path.
                        fileName = Path.Combine(_environment.WebRootPath, "ProfilePictures") + $@"\{newFileName}";



                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                        updateUser.ProfilePictureUrl = "~/ProfilePictures/" + newFileName;
                    }
                }
            }

            if (_context.Update(updateUser))
            {
                return RedirectToAction("Profile", "Home");
            }
            else
            {
                return View(user);
            }
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
