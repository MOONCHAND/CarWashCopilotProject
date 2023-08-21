using CarWashCopilot.Model;
using Microsoft.EntityFrameworkCore;

namespace CarWashCopilot.Repository
{
    public class ImpUser : IUser
    {
        private readonly UserContext _user;

        public ImpUser(UserContext user)
        {
            _user = user;
        }
        public async Task<User> AddUser(User user)
        {
            try
            {
                var add = _user.Users.Add(user);
                await _user.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
            return user;
        }

        public async Task<bool> CheckEmailExistAsync(string Email)
        {
            var check = await _user.Users.AnyAsync(x => x.Email == Email);
            return check;
        }

        public async Task DeleteUser(int Id)
        {
            User deleteUser = _user.Users.Find(Id);
            try
            {
                var delete = _user.Users.Remove(deleteUser);
                await _user.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                List<User> user = await _user.Users.ToListAsync();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetByID(int Id)
        {
            try
            {
                User user = await _user.Users.FindAsync(Id);
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> Login(Login login)
        {
            var user = await _user.Users.FirstOrDefaultAsync(x => x.Email == login.Email && x.Password == login.Password && x.Role == login.Role);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User> UpdateUser(int Id, User user)
        {
            var cus = await _user.Users.FindAsync(Id);
            if (cus != null)
            {
                cus.FirstName = user.FirstName;
                cus.LastName = user.LastName;
                cus.Password = user.Password;
                cus.PhNumber = user.PhNumber;
                cus.Role = user.Role;
                cus.Email = user.Email;
                cus.IsActive = user.IsActive;
                await _user.SaveChangesAsync();
            }
            return cus;
        }
    }
}
