using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tvitter.Core.Service;
using Tvitter.Model.Entities;

namespace Tvitter.Web.Controllers
{
   
    public class NotificationController : Controller
    {
        private readonly ICoreService<Notification> _notificationContext;
        private readonly ICoreService<User> _userContext;


        public NotificationController(ICoreService<Notification> notificationContext, ICoreService<User> userContext)
        {
            _notificationContext = notificationContext;
            _userContext = userContext;
        }

        public IActionResult Index()
        {
            Guid id = Guid.Parse(User.FindFirst("ID").Value);
            var user = _userContext.GetById(id);
            user.Notifications = _notificationContext.GetDefault(x => x.UserId == user.ID && x.Status == Core.Entity.Enum.Status.Active);

            IEnumerable<Notification> notifications = _notificationContext.GetDefault(x => x.UserId == user.ID).OrderByDescending(x => x.CreatedDate).ToList();


            foreach (var noti in user.Notifications)
            {
                noti.Status = Core.Entity.Enum.Status.None;
                _notificationContext.Update(noti);
            }

            return View(notifications);
        }
    }
}
