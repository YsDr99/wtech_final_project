using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Entity;

namespace Tvitter.Model.Entities
{
    public class Chat : CoreEntity
    {

        [ForeignKey("SenderId")]
        public User Sender { get; set; }
        public Guid SenderId { get; set; }

        [ForeignKey("RecieverId")]
        public User Reciever { get; set; }
        public Guid RecieverId { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
