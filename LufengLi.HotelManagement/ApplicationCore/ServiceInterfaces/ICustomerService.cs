using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerCardResponseModel>> GetUniqueCustomers();
        Task<List<RoomResponseModel>> GetRoomsByName(string name);
        Task<IEnumerable<Service>> GetRoomServices(string name);
        Task<IEnumerable<ServiceResponseModel>> GetServicesByName(string name);


    }
}
