using CarWashCopilot.Model;

namespace CarWashCopilot.Repository
{
    public interface IPackage
    {
        Task<List<Package>> GetAll();
        Task<Package> GetByID(int Id);
        Task<Package> Add(Package package);
        Task<Package> Update(int Id, Package package);
        Task Delete(int Id);
    }
}
