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
    public class TagMap : CoreMap<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {

            builder.ToTable("Tags");
            builder.HasIndex(x => x.Name).IsUnique(true);

            base.Configure(builder);
        }
    }
}
