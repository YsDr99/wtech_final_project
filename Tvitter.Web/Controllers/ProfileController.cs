﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tvitter.Core.Service;
using Tvitter.Model.Entities;
using Tvitter.Web.Models;

namespace Tvitter.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ICoreService<User> _userContext;
        private readonly ICoreService<Follow> _followContext;
        private readonly ICoreService<Tweet> _tweetContext;
        private IWebHostEnvironment _environment;

        public ProfileController(ICoreService<User> usercontext, ICoreService<Follow> followContext,
            ICoreService<Tweet> tweetContext, IWebHostEnvironment environment)
        {
            _userContext = usercontext;
            _followContext = followContext;
            _tweetContext = tweetContext;
            _environment = environment;
        }

        public IActionResult Index()
        {
            Guid id = Guid.Parse(User.FindFirst("ID").Value);
            var user = _userContext.GetById(id);
            user.Followers = _followContext.GetDefault(x => x.FollowingId == user.ID);
            user.Following = _followContext.GetDefault(x => x.FollowerId == user.ID);
            user.Tweets = _tweetContext.GetDefault(x => x.UserId == user.ID);
            return View(user);
        }

        public IActionResult Edit()
        {
            Guid id = Guid.Parse(User.FindFirst("ID").Value);
            return View(_userContext.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            var updateUser = _userContext.GetById(user.ID);
            updateUser.Fullname = user.Fullname;
            updateUser.About = user.About;
            updateUser.Location = user.Location;
            updateUser.Website = user.Website;
            updateUser.BirthDate = user.BirthDate;
            updateUser.gender = user.gender;

            if (HttpContext.Request.Form.Files != null)
            {
                var files = HttpContext.Request.Form.Files;

                foreach (var file in files)
                {
                    if (file.Length > 0 && file.ContentType.Contains("image"))
                    {
                        Upload upload = new Upload(file, "ProfilePictures", _environment);

                        updateUser.ProfilePictureUrl = upload.UploadFile();
                    }
                }
            }

            if (_userContext.Update(updateUser))
            {
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                return View(user);
            }
        }

        public IActionResult UserProfile(string username)
        {
            if(username == null)
            {
                Guid id = Guid.Parse(User.FindFirst("ID").Value);
                var user = _userContext.GetById(id);
                user.Followers = _followContext.GetDefault(x => x.FollowingId == user.ID);
                user.Following = _followContext.GetDefault(x => x.FollowerId == user.ID);
                user.Tweets = _tweetContext.GetDefault(x => x.UserId == user.ID);
                return View(user);
            }
            else
            {
                if (User.FindFirst("Username").Value == username)
                {
                    return RedirectToAction("Index", "Profile");
                }
                var user = _userContext.GetFirstOrDefault(x=>x.Username == username);
                if(user == null)
                {
                    Guid id = Guid.Parse(User.FindFirst("ID").Value);
                    user = _userContext.GetById(id);
                }
                user.Followers = _followContext.GetDefault(x => x.FollowingId == user.ID);
                user.Following = _followContext.GetDefault(x => x.FollowerId == user.ID);
                user.Tweets = _tweetContext.GetDefault(x => x.UserId == user.ID);
               
                return View(user);
            }

           
        }

        [ActionName("UserProfile"), HttpPost]
        public IActionResult UserProfilePost(string username)
        {
            if (!_userContext.Any(x => x.Username == username))
            {
                return RedirectToAction("UserNotFound", "Profile", new { Username = username });
            }
            else
            {
                return Redirect("/"+username);
            }
        }

        public IActionResult UserNotFound(string Username)
        {
            User user = new User();
            user.Username = Username;
            return View(user);
        }

        [HttpPost]
        public IActionResult Follow(string id, string username, string action)
        {
            if (action.Equals("follow"))
            {
                Follow follow = new Follow();
                follow.FollowerId = Guid.Parse(User.FindFirst("ID").Value);
                follow.FollowingId = Guid.Parse(id);
                _followContext.Add(follow);
            }
            else
            {
                Guid followerId = Guid.Parse(User.FindFirst("ID").Value);
                Guid followingId = Guid.Parse(id);
                Follow follow = _followContext.GetFirstOrDefault(x => x.FollowerId == followerId && x.FollowingId == followingId);
                _followContext.RemovePerma(follow);
            }
            return Redirect("/" + username);

        }

    }
}
