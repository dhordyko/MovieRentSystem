using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRent.Models;
using MovieRent.View_Models;
using System.Data.Entity;
namespace MovieRent.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController() {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            return View();
        }
       
     

   
        public ViewResult CustomerForm(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                
                var customerView = new MembershipView
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };

                return View( customerView);
            }
            else
            {
                if (customer.Id == null)
                    _context.Customers.Add(customer);
                //else
                //{
                //    var customerDb = _context.Customers.Single(c => c.Id == customer.Id);
                //    customerDb.Name = customer.Name;
                //    customerDb.BirthDate = customer.BirthDate;
                //    customerDb.isSubsribedtoNewsLetter = customer.isSubsribedtoNewsLetter;
                //    customerDb.MembershipTypeId = customer.MembershipTypeId;
                //}
                _context.SaveChanges();
                return View("Index");
            }
        }
        public ViewResult Edit(int id)
        {
            var customer = _context.Customers.FirstOrDefault(m => m.Id == id);
           
            var customerView = new MembershipView
            {   
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };
            return View("CustomerForm", customerView);
        }
       

    }
}