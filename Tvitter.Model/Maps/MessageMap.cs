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
    public class MessageMap : CoreMap<Message>
    {
        public override void Configure(EntityTypeBuilder<Message> builder)
        {

            builder.ToTable("Messages");
            builder.Property(x => x.Content).HasMaxLength(1000).IsRequired(true);
            builder.Property(x => x.IsPerson1Sent).IsRequired(true);
            builder.Property(x => x.ChatId).IsRequired(true);

            base.Configure(builder);
        }
    }
}
