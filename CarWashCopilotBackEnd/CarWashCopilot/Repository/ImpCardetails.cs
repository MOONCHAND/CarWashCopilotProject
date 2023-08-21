﻿using CarWashCopilot.Model;
using Microsoft.EntityFrameworkCore;

namespace CarWashCopilot.Repository
{
    public class ImpCardetails : ICardetails
    {
        private readonly UserContext _car;

        public ImpCardetails(UserContext car)
        {
            _car = car;
        }
        public async Task<Cardetails> Add(Cardetails cardetails)
        {
            try
            {
                var add = _car.Cardetails.Add(cardetails);
                await _car.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
            return cardetails;
        }

        public async Task Delete(int Id)
        {
            Cardetails deletecardetails = _car.Cardetails.Find(Id);
            try
            {
                var delete = _car.Cardetails.Remove(deletecardetails);
                await _car.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Cardetails>> GetAll()
        {
            try
            {
                List<Cardetails> cardetails = await _car.Cardetails.ToListAsync();
                return cardetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cardetails> GetByID(int Id)
        {
            try
            {
                Cardetails cardetails = await _car.Cardetails.FindAsync(Id);
                return cardetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cardetails> Update(int Id, Cardetails cardetails)
        {
            var cus = await _car.Cardetails.FindAsync(Id);
            if (cus != null)
            {
                cus.Carmodel = cardetails.Carmodel;
                cus.Status = cardetails.Status;


                await _car.SaveChangesAsync();
            }
            return cus;
        }
    }
}
