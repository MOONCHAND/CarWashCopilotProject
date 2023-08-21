using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarWashCopilot.Model
{
    public class UserContext :DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Cardetails> Cardetails { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Orderdetails> Orderdetails { get; set; }

    }
}
