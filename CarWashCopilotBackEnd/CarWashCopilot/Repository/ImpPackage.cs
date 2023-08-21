using CarWashCopilot.Model;
using Microsoft.EntityFrameworkCore;

namespace CarWashCopilot.Repository
{
    public class ImpPackage : IPackage
    {
        private readonly UserContext _package;

        public ImpPackage(UserContext package)
        {
            _package = package;
        }
        public async Task<Package> Add(Package package)
        {
            try
            {
                var add = _package.Packages.Add(package);
                await _package.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
            return package;
        }

        public async Task Delete(int Id)
        {
            Package deletePackage = _package.Packages.Find(Id);
            try
            {
                var delete = _package.Packages.Remove(deletePackage);
                await _package.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Package>> GetAll()
        {
            try
            {
                List<Package> package = await _package.Packages.ToListAsync();
                return package;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Package> GetByID(int Id)
        {
            try
            {
                Package package = await _package.Packages.FindAsync(Id);
                return package;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Package> Update(int Id, Package package)
        {
            var cus = await _package.Packages.FindAsync(Id);
            if (cus != null)
            {
                cus.Name = package.Name;
                cus.Description = package.Description;
                cus.price = package.price;
                cus.Status = package.Status;

                await _package.SaveChangesAsync();
            }
            return cus;
        }
    }
}
