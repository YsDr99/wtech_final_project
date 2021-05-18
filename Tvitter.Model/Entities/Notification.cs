using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Entity;

namespace Tvitter.Model
{
    public class Notification : CoreEntity
    {
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }

        public bool IsActive { get; set; }
        public string Content { get; set; }
    }
}
