using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

        // GET: Customers
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            DetailsViewModel viewModel = new DetailsViewModel();
            viewModel.Customer = customer;
            viewModel.MembershipType = customer.MembershipType;
            
            if (customer == null)
                return HttpNotFound();

            return View(viewModel);
        }


        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("Customer", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save( Customer customer )
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("Customer", viewModel);
            }
            else
            {
                if (customer.Id == 0)
                    _context.Customers.Add(customer);
                else
                {
                    var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                    customerInDB.Name = customer.Name;
                    customerInDB.BirthDay = customer.BirthDay;
                    customerInDB.MembershipTypeId = customer.MembershipTypeId;
                    customerInDB.IsSusbcribedToNewsLetter = customer.IsSusbcribedToNewsLetter;
                }

                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Customers");
        }

        
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            else
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("Customer", viewModel);
            }
        }
    }
}