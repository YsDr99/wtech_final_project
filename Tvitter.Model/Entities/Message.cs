using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Entity;

namespace Tvitter.Model
{
    public class Message : CoreEntity
    {
        [ForeignKey("ChatId")]
        public Chat Chat { get; set; }
        public Guid ChatId { get; set; }

        public bool IsPerson1Sent { get; set; }
        public string Content { get; set; }
    }
}
