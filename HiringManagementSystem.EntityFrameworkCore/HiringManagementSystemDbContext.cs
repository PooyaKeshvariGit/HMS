using HiringManagementSystem.Domain.Aggregations.PersonAggregate;
using HiringManagementSystem.Domain.Aggregations.TagAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HiringManagementSystem.EntityFrameworkCore
{
    public class HiringManagementSystemDbContext : DbContext
    {
        #region [-Ctor-]

        public HiringManagementSystemDbContext(DbContextOptions<HiringManagementSystemDbContext> contextOptions)
            : base(contextOptions)
        {

        }

        #endregion

        #region [-OnModelCreating(ModelBuilder modelBuilder)-]

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region [-Aggregate-DbSet<>-]

        public DbSet<Tag> Tag { get; set; }
        public DbSet<Person> Person { get; set; }

        #endregion
    }
}
