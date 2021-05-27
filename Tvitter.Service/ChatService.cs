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
    public class ChatService<T> : BaseService<T>, IChatService<T> where T : Chat
    {
        public ChatService(DatabaseContext dbContext) : base(dbContext)
        {

        }

        public ICollection<T> GetChats(Expression<Func<T, bool>> exp)
        {
            var chats = context.Set<T>().Where(exp).Include(x => x.Reciever).Include(x => x.Sender)
                .Include(x => x.Messages.OrderBy(y => y.CreatedDate)).ToList();
            return chats;
        }
    }
}
