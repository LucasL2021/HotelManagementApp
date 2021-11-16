using ApplicationCore.ServiceInterfaces;
using Infrastructure.Services;
using LufengLi.HotelManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LufengLi.HotelManagement.MVC.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerService _customerService;
        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var customerCards = _customerService.GetUniqueCustomers();
            return View(customerCards);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
