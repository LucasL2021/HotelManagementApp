using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(HotelManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Customer>> GetUniqueCustomers()
        {
            return await hotelManagementDbContext.CUSTOMERS
            .GroupBy(c => new
            {
                name = c.Cname
            })
            .OrderBy(c => c.Key.name)
            .Select(c => new Customer
            {
                Cname = c.Key.name
            
            }).ToListAsync();
        }

        public async Task<Customer> GetCustomerByName(string name) 
        {
            return await hotelManagementDbContext.CUSTOMERS.FirstOrDefaultAsync(c => c.Cname == name);
        }

        public async Task<IEnumerable< Room>> GetRoomsByName(string name)
        {
            var rooms = from r in hotelManagementDbContext.ROOMS
                        join c in hotelManagementDbContext.CUSTOMERS
                        on r.Id equals c.Room.Id
                        select r;
                       
            return rooms;
        }
        public async Task<IEnumerable<Service>> GeServicesByName(string name)
        {
            var services = from s in hotelManagementDbContext.SERVICES
                           join c in hotelManagementDbContext.CUSTOMERS
                           on s.Room.Id equals c.Room.Id
                           where c.Cname == name
                           select s;

            return services;
        }
    }
}

