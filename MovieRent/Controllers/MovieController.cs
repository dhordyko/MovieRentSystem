using MovieRent.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Globalization;
using MovieRent.View_Models;
using MovieRent.Models;
using System.IO;

namespace MovieRent.Controllers
{
    public class MovieController : Controller
    {   
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            if (User.IsInRole(Role.Manage));
                return View("Index");
            return View("ReadOnly");
            var movies = _context.Movies.Include(m=>m.GenreType).ToList();
       
        }
       
        public ActionResult MovieForm()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            var viewMovie = new MovieViewModel
            {   Movie=new Movie(),
                GenreTypes = _context.GenreTypes.ToList(),
               Countries=_context.Countries.ToList(),
               actList=list
                };

           
            return View(viewMovie);
        }
        [HttpPost]
        public ActionResult MovieForm(Movie movie, FormCollection form)
        {

            if (!ModelState.IsValid)
            {
                List<SelectListItem> list = new List<SelectListItem>();
                var viewMovie = new MovieViewModel
                {
                    Movie = movie,
                    GenreTypes = _context.GenreTypes.ToList(),
                    Countries=_context.Countries.ToList(),
                    actList = list
                };

                return View("MovieForm", viewMovie);


            }

            else {
                if (HttpContext.Request.Files.AllKeys.Any())
                {
                    // Get the uploaded image from the Files collection
                    var httpPostedFile = HttpContext.Request.Files[0];

                    if (httpPostedFile != null)
                    {
                        // Validate the uploaded image(optional)

                        // Get the complete file path
                        var fileSavePath = Path.Combine(HttpContext.Server.MapPath("~/Img"), httpPostedFile.FileName);

                        // Save the uploaded file to "UploadedFiles" folder
                        httpPostedFile.SaveAs(fileSavePath);
                        movie.Image = httpPostedFile.FileName;
                    }
                }
                foreach (var key in form.Keys)
                {
                    var value = form["Movie.Actors".ToString()];
                    movie.Actors = value;
                }
                //var SelectedValues = form["selectedAct"];
                // movie.Actors = string.Join(",", SelectedValues);

                _context.Movies.Add(movie);

                _context.SaveChanges();
                return RedirectToAction("Index");

            }
        }
        
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m=>m.Id==id);
        
            var x = movie.Actors.Split(',');
            var selectListItems = x.Select(m => new SelectListItem()).ToList();

            var MovieView = new MovieViewModel()
            {
                Movie = movie,
                GenreTypes = _context.GenreTypes.ToList(),
                Countries=_context.Countries.ToList(),
                actList = selectListItems
            };
            return View("MovieForm",MovieView);
        }
    }
}