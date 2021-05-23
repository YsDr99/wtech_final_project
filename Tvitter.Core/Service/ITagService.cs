using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Entity;

namespace Tvitter.Core.Service
{
    interface ITagService
    {
    }
    public interface ITagService<T> : ICoreService<T> where T : CoreEntity
    {
        public List<Tuple<string, int>> GetTrends();
        public ICollection<T> GetAllTags();
        public T GetTag(Expression<Func<T, bool>> exp);
    }
}
