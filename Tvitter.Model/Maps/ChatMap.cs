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
    public class ChatMap : CoreMap<Chat>
    {
        public override void Configure(EntityTypeBuilder<Chat> builder)
        {

            builder.ToTable("Chats");
            builder.HasIndex(x => x.Person1Id).IsUnique(false);
            builder.HasIndex(x => x.Person2Id).IsUnique(false);
            builder.Property(x => x.Person1Id).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Person2Id).HasMaxLength(100).IsRequired(true);
            base.Configure(builder);
        }
    }
}
