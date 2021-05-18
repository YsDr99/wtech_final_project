using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tvitter.Core.Map;

namespace Tvitter.Model.Maps
{
    public class UserMap : CoreMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("Users");
            builder.HasIndex(x => x.Username).IsUnique(true);
            builder.Property(x => x.Username).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Password).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(250).IsRequired(true);
            builder.Property(x => x.Fullname).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.About).HasMaxLength(1000).IsRequired(true);
            builder.Property(x => x.Location).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.Website).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.BirthDate).IsRequired(false);
            builder.Property(x => x.ProfileBackgroundImageUrl).HasMaxLength(1000).IsRequired(false);
            builder.Property(x => x.ProfilePictureUrl).HasMaxLength(1000).IsRequired(false);
            builder.Property(x => x.gender).HasMaxLength(10).IsRequired(false);


            base.Configure(builder);
        }
    }
}
