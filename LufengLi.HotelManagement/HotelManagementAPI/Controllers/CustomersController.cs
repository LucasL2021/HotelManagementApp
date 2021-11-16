using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("UniqueCustomers")]
        public async Task<IActionResult> GetUniqueCustomers()
        {
            var customers = await _customerService.GetUniqueCustomers();
            return Ok(customers);
        }

        [HttpGet]
        [Route("/room/{name}")]
        public async Task<IActionResult> GetRoomsByName(string name)
        {
            var bookings = await _customerService.GetRoomsByName(name);
            return Ok(bookings);
        }

        [HttpGet]
        [Route("/service/{name}")]
        public async Task<IActionResult> GetServicesByName(string s)
        {
            var services = await _customerService.GetServicesByName(s);
            return Ok(services);
        }
    }
}
