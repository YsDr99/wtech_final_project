using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Entity.Enum;
using Tvitter.Core.Map;
using Tvitter.Model.Entities;

namespace Tvitter.Model.Maps
{
    public class NotificationMap : CoreMap<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {

            builder.ToTable("Notifications");
            builder.Property(x => x.Content).HasMaxLength(1000).IsRequired(true);
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.Type).IsRequired(true).HasDefaultValue(NotificationType.None);

            base.Configure(builder);
        }
    }
}
