using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Service;
using Tvitter.Model;
using Tvitter.Model.Entities;

namespace Tvitter.Service
{
    public class NotificationService<T> : BaseService<T>, INotificationService<T> where T : Notification
    {
        public NotificationService (DatabaseContext dbContext) : base(dbContext)
        {

        }

        public ICollection<T> GetShadowDefault(Expression<Func<T, bool>> exp)
        {
            var notifications = context.Set<T>().Where(exp).AsNoTracking();
            return notifications.ToList();
        }
    }
}
