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
    public class MessageCountViewComponent : ViewComponent
    {
        private readonly IChatService<Chat> _chatContext;

        public MessageCountViewComponent(IChatService<Chat> chatContext)
        {
            _chatContext = chatContext;
        }

        public IViewComponentResult Invoke(Guid id)
        {

            var chats = _chatContext.GetChats(x => x.SenderId == id || x.RecieverId == id);
            int count = 0;
            foreach (var chat in chats)
            {
                foreach (var msg in chat.Messages)
                {
                    if (msg.SenderId != id && msg.Status == Status.Active)
                    {
                        count++;
                        break;
                    }
                }
            }
            TempData["NewMsgCount"] = count > 0 ? count.ToString() : "";
            return View();
        }
    }
}
