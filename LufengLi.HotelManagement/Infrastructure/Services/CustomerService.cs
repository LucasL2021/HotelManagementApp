using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using AutoMapper;

namespace Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public CustomerService(ICustomerRepository customerRepository, IRoomRepository roomRepository, IServiceRepository serviceRepository, IRoomTypeRepository roomTypeRepository)
        {
            _customerRepository = customerRepository;
            _roomRepository = roomRepository;
            _serviceRepository = serviceRepository;
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<List<CustomerCardResponseModel>> GetUniqueCustomers()
        {
            var customers = await _customerRepository.GetUniqueCustomers();
            var customerCards = new List<CustomerCardResponseModel>();
            foreach (var customer in customers)
            {
                var c = await _customerRepository.GetCustomerByName(customer.Cname);
                customerCards.Add(new CustomerCardResponseModel
                {
                    Id = c.Id,
                    Cname = c.Cname,
                    Address = c.Address,
                    Phone = c.Phone
                });
            }
            return customerCards;
        }

        public async Task<List<RoomResponseModel>> GetRoomsByName(string name)
        {
            
            var rooms = await _customerRepository.GetRoomsByName(name);
            var res = new List<RoomResponseModel>();
            foreach (var r in rooms) 
            {
                res.Add(new RoomResponseModel
                {
                    Id = r.Id,
                    RTDESC = r.RoomType.RTDESC,
                    Rent = r.RoomType.Rent
                });
            }
            return res;
        }
        public async Task<IEnumerable<ServiceResponseModel>> GetServicesByName(string name) 
        {
            var services =await _customerRepository.GeServicesByName(name);
            var res = new List<ServiceResponseModel>();
            foreach (var s in services)
            {
                res.Add(new ServiceResponseModel
                {
                    Id = s.Id,
                    RoomNO = s.RoomNO,
                    SDESC = s.SDESC,
                    Amount = s.Amount,
                    ServiceDate = s.ServiceDate
                });
            }
            return res;
        }

        public Task<IEnumerable<Service>> GetRoomServices(string name)
        {
            throw new NotImplementedException();
        }
    }
}
