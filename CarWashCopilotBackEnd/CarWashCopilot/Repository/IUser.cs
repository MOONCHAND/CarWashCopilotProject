using CarWashCopilot.Model;

namespace CarWashCopilot.Repository
{
    public interface IUser
    {
        Task<List<User>> GetAll();
        Task<User> GetByID(int Id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(int Id, User user);
        Task DeleteUser(int Id);
        Task<User> Login(Login login);
        //email validation
        Task<bool> CheckEmailExistAsync(string Email);
    }
}
