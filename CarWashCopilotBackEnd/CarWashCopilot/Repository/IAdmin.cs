using CarWashCopilot.Model;

namespace CarWashCopilot.Repository
{
    public interface IAdmin
    {
        Task<List<Admin>> GetAll();
        Task<Admin> GetByID(int Id);
        Task<Admin> Add(Admin admin);
        Task<Admin> Update(int Id, Admin admin);
        Task Delete(int Id);
        Task<Admin> AdminLogin(AdminLogin alogin);
        Task<bool> CheckEmailExistAsync(string Email);
    }
}
