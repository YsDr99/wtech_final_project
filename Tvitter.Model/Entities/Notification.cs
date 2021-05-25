using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Entity;
using Tvitter.Core.Entity.Enum;

namespace Tvitter.Model.Entities
{
    public class Notification : CoreEntity
    {
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }

        public string Content { get; set; }

        public NotificationType Type { get; set; }

        public Guid? TweetId { get; set; }
    }
}
