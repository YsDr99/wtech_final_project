﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Entity;

namespace Tvitter.Core.Service
{
    public interface INotificationService<T> : ICoreService<T> where T : CoreEntity
    {
        ICollection<T> GetShadowDefault(Expression<Func<T, bool>> exp);
    }
}
