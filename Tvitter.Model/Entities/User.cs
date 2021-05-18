using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Entity;
using Tvitter.Model.Entities;

namespace Tvitter.Model
{
    public class User : CoreEntity
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string About { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ProfileBackgroundImageUrl { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string gender { get; set; }

        [NotMapped]
        public ICollection<Follow> Followers { get; set; }
        [NotMapped]
        public ICollection<Follow> Following { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Mention> Mentions { get; set; }


    }
}
