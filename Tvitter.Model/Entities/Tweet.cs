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
    public class Tweet : CoreEntity
    {
        public Guid? RetweetId { get; set; }
        [NotMapped]
        public Tweet Retweet { get; set; }
        [NotMapped]
        public int RetweetCount { get; set; }

        public Guid? BelongsTo { get; set; }
        [NotMapped]
        public Guid? Parent { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
        public Guid? TagId { get; set; }

        public string MediaUrl { get; set; }
        public string Text { get; set; }

        public TweetType Type { get; set; }

        [NotMapped]
        public virtual ICollection<Tweet> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Mention> Mentions { get; set; }

    }
}
