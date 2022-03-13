using HiringManagementSystem.Domain.Aggregations.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiringManagementSystem.EntityFrameworkCore.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        #region [-Configure(EntityTypeBuilder<Person> builder)-]

        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(p=>p.FirstName).IsRequired().HasMaxLength(40);
            builder.Property(p=>p.Family).IsRequired().HasMaxLength(50);
            builder.Property(p=>p.NationalId).IsRequired().HasMaxLength(20);
        }

        #endregion
    }
}
