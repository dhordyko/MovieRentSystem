using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRent.Models;
namespace MovieRent.View_Models
{
    public class RegisterListView
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
        
    }
}