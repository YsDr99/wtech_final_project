using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tvitter.Core.Service;
using Tvitter.Model.Entities;

namespace Tvitter.Web.Controllers
{
    public class MessageController : Controller
    {
        private readonly IChatService<Chat> _chatContext;
        private readonly ICoreService<User> _userContext;
        private readonly ICoreService<Message> _messageContext;

        public MessageController(IChatService<Chat> chatContext, ICoreService<User> userContext, ICoreService<Message> messageContext)
        {
            _chatContext = chatContext;
            _userContext = userContext;
            _messageContext = messageContext;
        }

        public IActionResult Index(int count)
        {
            var id = User.FindFirst("ID").Value;
            var user = _userContext.GetById(Guid.Parse(id));
            var chats = _chatContext.GetChats(x => x.RecieverId == user.ID || x.SenderId == user.ID)
                .OrderByDescending(x => x.ModifiedDate ?? x.CreatedDate).ToList();

            foreach (var chat in chats.Take(1))
            {
                var messages = _messageContext.GetDefault(x => x.ChatId == chat.ID && x.Status == Core.Entity.Enum.Status.Active && x.SenderId != Guid.Parse(id));
                foreach (var mes in messages)
                {
                    mes.Status = Core.Entity.Enum.Status.None;
                    _messageContext.Update(mes);
                }
            }

            ViewBag.NewCount = count;
            return View(chats);
        }


        public IActionResult StartChat(string receiverId)
        {
            var id = User.FindFirst("ID").Value;
            var existChat = _chatContext.GetFirstOrDefault(x => (x.RecieverId == Guid.Parse(id) && x.SenderId == Guid.Parse(receiverId)) ||
                (x.SenderId == Guid.Parse(id) && x.RecieverId == Guid.Parse(receiverId)));
            if (existChat != null)
            {
                _chatContext.Update(existChat);
            }
            else
            {
                Chat chat = new Chat()
                {
                    SenderId = Guid.Parse(id),
                    RecieverId = Guid.Parse(receiverId),
                };
                _chatContext.Add(chat);
            }


            return RedirectToAction("Index", "Message");
        }

        [HttpPost]
        public IActionResult SendMsg(string Msg, string chatId)
        {
            var id = User.FindFirst("ID").Value;
            var chat = _chatContext.GetById(Guid.Parse(chatId));
            Message message = new Message()
            {
                ChatId = Guid.Parse(chatId),
                SenderId = Guid.Parse(id),
                Content = Msg,
                Status = Core.Entity.Enum.Status.Active
            };
            _messageContext.Add(message);
            _chatContext.Update(chat);
            return RedirectToAction("Index", "Message");
        }
    }
}
