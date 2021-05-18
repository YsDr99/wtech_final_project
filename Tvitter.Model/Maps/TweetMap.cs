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
    public class TweetMap : CoreMap<Tweet>
    {
        public override void Configure(EntityTypeBuilder<Tweet> builder)
        {

            builder.ToTable("Tweets");
            builder.Property(x => x.MediaUrl).HasMaxLength(1000).IsRequired(false);
            builder.Property(x => x.Text).HasMaxLength(1000).IsRequired(true);
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.TagId).IsRequired(false);
            builder.Property(x => x.IsComment).IsRequired(true);
            builder.HasIndex(x => x.IsComment).IsUnique(false);

            base.Configure(builder);
        }
    }
}
