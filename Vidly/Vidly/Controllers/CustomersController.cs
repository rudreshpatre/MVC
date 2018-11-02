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
            return View();
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

        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var model = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var model = new CustomerFormViewModel
                {
                    MembershipTypes = _context.MembershipTypes.ToList(),
                    Customer = customer
                };

                return View("CustomerForm",model);

            }
            if (customer.Id == 0)
            {
              _context.Customers.Add(customer);
            }
            else
            {
                var cuz = _context.Customers.Where(c => c.Id == customer.Id).Select(c => c).FirstOrDefault();
                cuz.Name = customer.Name;
                cuz.BirthDate = customer.BirthDate;
                cuz.MembershipTypeId = customer.MembershipTypeId;
                cuz.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }            
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Where(c=>c.Id == id).Select(c=>c).FirstOrDefault();

            if (customer == null)
            {
                return new HttpNotFoundResult();
            }
            var model = new CustomerFormViewModel
            {
                MembershipTypes =_context.MembershipTypes.ToList() ,
                Customer = customer
            };
            return View("CustomerForm",model);
        }
       
    }
}