using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;

namespace Application.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ViewResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }
        private IEnumerable<Movie> GetCustomers()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Anchal" },
                new Movie { Id = 2, Name = "Anjali" }
            };
        }
    }
}