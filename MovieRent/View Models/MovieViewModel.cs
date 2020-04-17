using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRent.Models;
using System.Web.Mvc;
using System.Collections;

namespace MovieRent.View_Models
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<GenreType> GenreTypes { get; set;}

        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<SelectListItem> actList { get; set; }
        public IEnumerable selectedAct { get; set; }
        public IEnumerable<Movie> Genre { get; set; }
        public string Title {
          
             get { if (Movie.Id == null)
                { return "Add Movie"; }
                else { return "Edit Movie"; }
               
            }
            
        }

       
    }
}