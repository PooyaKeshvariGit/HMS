
namespace HiringManagementSystem.Domain.Frameworks.Interfaces
{
    public interface IEntity<P_PrimaryKey>
    {
        P_PrimaryKey Id { get; set; }
    }
}
