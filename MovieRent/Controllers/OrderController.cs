using MovieRent.Models;
using MovieRent.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace MovieRent.Controllers
{
    public class OrderController : Controller
    {
        // GET: Orders
        private ApplicationDbContext _context;

        public OrderController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
        
            
            return View();
     
            
        }
        public ViewResult OrderForm(string id)
        {

            var x = _context.Orders.Include(t=>t.Customer.MembershipType).Where(m => m.OrderNmb == id).ToList();
         


           


            return View("OrderForm", x);
        }
      


    }
}