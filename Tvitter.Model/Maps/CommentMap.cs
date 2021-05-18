using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Map;
using Tvitter.Model.Entities;

namespace Tvitter.Model.Maps
{
    public class CommentMap : CoreMap<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {

            builder.ToTable("Comments");
            builder.Property(x => x.CommentTweetId).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.TweetId).IsRequired(true);
            base.Configure(builder);
        }
    }
}
