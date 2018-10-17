using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Custumers
        public ActionResult Index()
        {
            CustomersViewModel model = new CustomersViewModel()
            {
                Customers = _context.Customers.Include(c=>c.MembershipType).ToList()
            };
            return View(model);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var customerDetails = _context.Customers.Where(d => d.Id == id).Select(d => d).FirstOrDefault();
            if (customerDetails == null)
            {
                return new HttpNotFoundResult();
            }          
            return View(customerDetails);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var model = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
       
    }
}