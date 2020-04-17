using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRent.Models;
namespace MovieRent.View_Models
{
    public class MembershipView
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public IEnumerable<Orders> Orders { get; set; }
        public IEnumerable<Movie> MovieGenres { get; set; }
        public Movie Movie { get; set; }
        public Customer Customer { get; set; }
        public int user { get; set; }
        public string Title
        {
            get
            {
                if(Customer.Id==null)
                { return "Dodaj nowego użytkownika"; }
                else { return "Edytuj profil użytkownika"; }
            }
        }
    }
}