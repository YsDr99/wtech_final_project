using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tvitter.Core.Entity.Enum;
using Tvitter.Core.Service;
using Tvitter.Model.Entities;

namespace Tvitter.Web.Controllers
{
   
    public class NotificationController : Controller
    {
        private readonly INotificationService<Notification> _notificationContext;
        private readonly ICoreService<User> _userContext;


        public NotificationController(INotificationService<Notification> notificationContext, ICoreService<User> userContext)
        {
            _notificationContext = notificationContext;
            _userContext = userContext;

        }

        public IActionResult Index()
        {
            Guid id = Guid.Parse(User.FindFirst("ID").Value);
            var user = _userContext.GetById(id);

            IEnumerable<Notification> notifications = _notificationContext.GetShadowDefault(x => x.UserId == user.ID).OrderByDescending(x => x.CreatedDate).ToList();

            user.Notifications = _notificationContext.GetDefault(x => x.UserId == user.ID && x.Status == Status.Active);
            foreach (var noti in user.Notifications)
            {
                noti.Status = Status.None;
                _notificationContext.Update(noti);
            }

            return View(notifications);
        }
    }
}
