using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Custumers
        public ActionResult Index()
        {
            CustomersViewModel model = new CustomersViewModel()
            {
                Customers = GetCustomers()
            };
            return View(model);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            List<CustomerDetails> details = GetCustomerDetails();

            var customerDetails = details.Where(d => d.Id == id).Select(d => d).FirstOrDefault();
            if (customerDetails == null)
            {
                return new HttpNotFoundResult();
            }
            var model = new CustomerDetailsViewModel()
            {
                CustomerDetials = customerDetails
            };
            return View(model);
        }

        private static List<CustomerDetails> GetCustomerDetails()
        {
            return new List<CustomerDetails>()
            {
                new CustomerDetails{Id =1,Name = "Rudresh", Age = 10, Sex = "Male" },
                new CustomerDetails{Id =2,Name = "Morena", Age = 24, Sex="Female"}
            };
        }

        private static List<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer{ Id = 1, Name="Rudresh"},
                new Customer{ Id = 2,Name = "Morena"},
                new Customer{ Id = 3,Name = "Cute Girl"}
            };
        }
    }
}