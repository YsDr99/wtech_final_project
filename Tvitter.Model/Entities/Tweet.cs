using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Entity;

namespace Tvitter.Model.Entities
{
    public class Tweet : CoreEntity
    {
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
        public Guid? TagId { get; set; }

        public string MediaUrl { get; set; }
        public string Text { get; set; }
        public bool IsComment { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Mention> Mentions { get; set; }

    }
}
