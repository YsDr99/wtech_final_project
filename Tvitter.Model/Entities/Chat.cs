using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Entity;

namespace Tvitter.Model
{
    public class Chat : CoreEntity
    {
        public Guid Person1Id { get; set; }
        public Guid Person2Id { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
