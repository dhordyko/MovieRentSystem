using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieRent.Models
{
    public class Customer
    {
        
        public int? Id { get; set; }
        [Required(ErrorMessage ="Wpisz imię")]
        [StringLength(255)]
        [Display(Name ="Imię")]
        public string Name { get; set; }
      
        
        public MembershipType MembershipType { get; set; }
        [Display(Name ="Typ abonementu")]
        [Required(ErrorMessage = "Wybierz typ abonementu")]
        public byte MembershipTypeId { get; set; }
       
        [Display (Name ="Data urodzenia")]
        [Required(ErrorMessage = "Wpisz datę urodzenia")]
        
        public DateTime? BirthDate { get; set; }
        //public int Phone { get; set; }
        //public string Email { get; set;}
        //public string Address { get; set; } 
        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Wpisz swoje nazwisko")]

        public string SecondName { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Wpisz swój adres")]

        public string Address { get; set; }
        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Wpisz numer telefonu")]

        public int Phone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public Customer()
        {
            this.BirthDate = null;
           
        }
    }
}