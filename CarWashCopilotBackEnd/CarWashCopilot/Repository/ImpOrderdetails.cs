using CarWashCopilot.Model;
using Microsoft.EntityFrameworkCore;

namespace CarWashCopilot.Repository
{
    public class ImpOrderdetails : IOrderdetails
    {
        private readonly UserContext _order;

        public ImpOrderdetails(UserContext order)
        {
            _order = order;
        }
        public async Task<Orderdetails> Add(Orderdetails order)
        {
            try
            {
                var add = _order.Orderdetails.Add(order);
                await _order.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
            return order;
        }

        public async Task Delete(int Id)
        {
            Orderdetails deleteorder = _order.Orderdetails.Find(Id);
            try
            {
                var delete = _order.Orderdetails.Remove(deleteorder);
                await _order.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Orderdetails>> GetAll()
        {
            try
            {
                List<Orderdetails> order = await _order.Orderdetails.ToListAsync();
                return order;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Orderdetails> GetByID(int Id)
        {
            try
            {
                Orderdetails order = await _order.Orderdetails.FindAsync(Id);
                return order;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Orderdetails> Update(int Id, Orderdetails order)
        {
            var cus = await _order.Orderdetails.FindAsync(Id);
            if (cus != null)
            {
                cus.WashingInstructions = order.WashingInstructions;
                cus.Date = order.Date;
                cus.packagename = order.status;
                cus.description = order.description;
                cus.price = order.price;
                cus.city = order.city;
                cus.pincode = order.pincode;

                await _order.SaveChangesAsync();
            }
            return cus;
        }
    }
}
