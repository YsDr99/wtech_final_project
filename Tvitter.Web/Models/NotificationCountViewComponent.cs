using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tvitter.Core.Entity.Enum;
using Tvitter.Core.Service;
using Tvitter.Model.Entities;

namespace Tvitter.Web.Models
{
    public class NotificationCountViewComponent : ViewComponent
    {
        private readonly ICoreService<User> _userContext;
        private readonly ICoreService<Notification> _notificationContext;

        public NotificationCountViewComponent(ICoreService<User> userContext, ICoreService<Notification> notificationContext)
        {
            _userContext = userContext;
            _notificationContext = notificationContext;
        }

        public IViewComponentResult Invoke(Guid id)
        {

            var user = _userContext.GetById(id);

            var ActiveNotifications = _notificationContext.GetDefault(x => x.Status == Status.Active && x.UserId == user.ID).ToList();
            TempData["NewNotificationCount"] = ActiveNotifications.Count > 0 ? ActiveNotifications.Count.ToString() : "";
            return View();
        }
    }
}
