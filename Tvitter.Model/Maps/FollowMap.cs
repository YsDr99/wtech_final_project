using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Map;

namespace Tvitter.Model.Maps
{

    public class FollowMap : CoreMap<Follow>
    {
        public override void Configure(EntityTypeBuilder<Follow> builder)
        {

            builder.ToTable("Follows");
            builder.HasIndex(x => x.FollowingId).IsUnique(false);
            builder.HasIndex(x => x.FollowerId).IsUnique(false);
            builder.Property(x => x.FollowerId).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.FollowingId).HasMaxLength(100).IsRequired(true);

            base.Configure(builder);
        }
    }
}
