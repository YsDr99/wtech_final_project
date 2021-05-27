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
    public class ChatMap : CoreMap<Chat>
    {
        public override void Configure(EntityTypeBuilder<Chat> builder)
        {

            builder.ToTable("Chats");
            builder.Property(x => x.SenderId).IsRequired(true);
            builder.HasOne(x => x.Sender).WithMany().OnDelete(DeleteBehavior.Restrict); ;
            builder.Property(x => x.RecieverId).IsRequired(true);
            builder.HasOne(x => x.Reciever).WithMany().OnDelete(DeleteBehavior.Restrict);
            base.Configure(builder);
        }
    }
}
