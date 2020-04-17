using MovieRent.Models;
using MovieRent.View_Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRent.Controllers
{
    public class HomeController : Controller
    { 
        private ApplicationDbContext _context;
        public HomeController()
        {

            _context = new ApplicationDbContext();
        }

       

        
        public ActionResult Index()
        {
            return View();
        }


        public ViewResult Fantasy()
        {
            var Genre = _context.Movies.Include(m => m.Coutnry).Where(a => a.GenreTypeId == 5).ToList();
             return View(Genre);

        }
        public ViewResult Dramat()
        {
             var Genre = _context.Movies.Include(m => m.Coutnry).Where(a => a.GenreTypeId == 7).ToList();
             return View(Genre);

        }
        public ViewResult Komedia()
        {
             var Genre = _context.Movies.Include(m => m.Coutnry).Where(a => a.GenreTypeId == 3).ToList();
             return View(Genre);

        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}