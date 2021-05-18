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
    public class MentionMap : CoreMap<Mention>
    {
        public override void Configure(EntityTypeBuilder<Mention> builder)
        {

            builder.ToTable("Mentions");
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.TweetId).IsRequired(true);
            base.Configure(builder);
        }
    }
}
