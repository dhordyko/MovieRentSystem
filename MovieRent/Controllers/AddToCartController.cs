using Microsoft.AspNet.Identity.Owin;
using MovieRent.Models;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using MovieRent.View_Models;
using System.Collections.Generic;
using System;
using System.Globalization;

namespace MovieRent.Controllers
{
    public class AddToCartController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;
        private Orders ords;
        public AddToCartController()
        {
            _context = new ApplicationDbContext();
            ords = new Orders();
        }
        public AddToCartController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        [HttpPost]
        public async Task<ActionResult> Add(Movie movie) {
            var userid = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var customerlgn = _context.Customers.SingleOrDefault(m => m.Email == userid.Email);
            var chosenmv = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
            List<MembershipView> li = new List<MembershipView>();
            var customerView = new MembershipView
            {
                Movie = chosenmv,
                Customer = customerlgn,
                MembershipTypes = _context.MembershipType.ToList(),
            };
            if (Session["cart"] == null)
            {
             li.Add(customerView);
                Session["cart"] = li;
                ViewBag.cart = li.Count();


                Session["count"] = 1;
                 }
            else
            {
               li = (List<MembershipView>)Session["cart"];
                if (!li.Any(n => n.Movie.Id == movie.Id))
                {
                    Session["cart"] = li;
                }

                li.Add(customerView);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
            return RedirectToAction("Fantasy", "Home");
    }
        [Authorize]
        public async Task<ActionResult> Myorder()
        {       
            var userid = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var customerlgn = _context.Customers.SingleOrDefault(m => m.Email == userid.Email);
            List<MembershipView> li = new List<MembershipView>();
            var customerView = new MembershipView
            {
                Movie = new Movie(),
                Customer = customerlgn,
                MembershipTypes = _context.MembershipType.ToList(),
            };
            
            if (Session["cart"] == null) {
                customerView.Movie.Name = "";
                li.Add(customerView);
                li.Remove(customerView);
                Session["cart"] = li;
                
                ViewBag.cart = li.Count();


                Session["count"] = 0;

            }

                return View((List<MembershipView>)Session["cart"]);

        }
        
        public ActionResult Remove(Movie movie)
        {
            List<MembershipView> li = (List<MembershipView>)Session["cart"];
            Predicate<MembershipView> oscarFinder = (MembershipView p) => { return p.Movie.Id == movie.Id; };
            var index = li.FindIndex(oscarFinder);
            li.RemoveAt(index);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Myorder", "AddToCart");

        }
        public string OrderId()
        {
            var random = new Random();
            var possibilities = Enumerable.Range(1, 100).ToList();
            var result = possibilities.OrderBy(number => random.Next()).Take(10).ToArray();
            return String.Join("",result);

        }

      
       
        [HttpPost]
        public async Task<ActionResult> AddOrders(FormCollection form)
        {
            
            List<MembershipView> li = (List<MembershipView>)Session["cart"];
            var userid = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var customerlgn = _context.Customers.SingleOrDefault(m => m.Email == userid.Email);
            DateTime localDate = DateTime.Now;
            var PickUpDate_txt = DateTime.Parse(form["calendar"].ToString(), CultureInfo.InvariantCulture).ToString("dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime PickUpDate = DateTime.Parse(form["calendar"].ToString(), CultureInfo.InvariantCulture);
            var RentPeriod = PickUpDate.AddDays(Convert.ToDouble(form["RentPeriod"])).ToString("dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            var x = OrderId();
           
            for (var i =0; i < li.Count(); i++)
            {
                ords.MovieId = li[i].Movie.Id;
                ords.Name = li[i].Movie.Name;
                ords.CustomerId = li[i].Customer.Id;
                ords.AbonementType = li[i].Customer.MembershipType.Name;
                ords.Cena = li[i].Customer.MembershipType.Price;
                ords.OrderDate = localDate;
                ords.OrderNmb = x;
                ords.DeliveryMode = form["DeliveryMode"].ToString();
                ords.RentPeriod = RentPeriod;
                ords.PickUpDate = PickUpDate_txt;
                _context.Orders.Add(ords);
                _context.SaveChanges();
            }
            Session["cart"] = null;
            return RedirectToAction("Myorder", "AddToCart");
        }

    }
   
    }


       


 