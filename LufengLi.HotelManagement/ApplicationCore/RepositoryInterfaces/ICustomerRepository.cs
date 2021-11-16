using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface ICustomerRepository: IAsyncRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetUniqueCustomers();

        Task<Customer> GetCustomerByName(string name);
        Task<IEnumerable<Room>> GetRoomsByName(string name);
        Task<IEnumerable<Service>> GeServicesByName(string name);


    }
}
