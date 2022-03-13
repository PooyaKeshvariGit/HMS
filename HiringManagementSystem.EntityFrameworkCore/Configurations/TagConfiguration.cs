using HiringManagementSystem.Domain.Aggregations.TagAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiringManagementSystem.EntityFrameworkCore.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        #region [-Configure(EntityTypeBuilder<Person> builder)-]

        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(t => t.TagName).IsRequired().HasMaxLength(30);
            builder.Property(t => t.Description).IsRequired().HasMaxLength(120);
            builder.HasOne(t => t.Person).WithMany(p => p.Tags).HasForeignKey(t => t.PersonId);
        }

        #endregion
    }
}
