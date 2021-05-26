using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tvitter.Core.Service;
using Tvitter.Model.Entities;

namespace Tvitter.Web.Models
{
    public class FollowSuggestionViewComponent : ViewComponent
    {
        private readonly ICoreService<User> _userContext;
        private readonly ICoreService<Follow> _followContext;

        public FollowSuggestionViewComponent(ICoreService<User> userContext, ICoreService<Follow> followContext)
        {
            _userContext = userContext;
            _followContext = followContext;
        }


        public IViewComponentResult Invoke()
        {
            var user = User as ClaimsPrincipal;
            Guid id = Guid.Parse(user.FindFirstValue("ID"));

            var follows = _followContext.GetAll().ToList();
            var users = _userContext.GetAll();

            var myFollowings = from u in users
                               join f in follows.Where(x => x.FollowerId == id)
                                   on u.ID equals f.FollowingId
                               select u;
            if (myFollowings.ToList().Count == 0)
            {
                return View(myFollowings);
            }
            var randomMyFollowing = myFollowings.OrderBy(r => Guid.NewGuid()).Take(1);

            var randomMyFollowingFollowings = from u in users
                                              join f in follows.Where(x => x.FollowerId == randomMyFollowing.ElementAt(0).ID)
                                                  on u.ID equals f.FollowingId
                                              select u;

            var ffThatIDontFollow = randomMyFollowingFollowings.Where(x => !myFollowings.Contains(x) && x.ID != id)
                                        .OrderBy(r => Guid.NewGuid()).Take(5);

            return View(ffThatIDontFollow.ToList());
        }
    }
}
