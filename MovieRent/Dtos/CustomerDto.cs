using MovieRent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MovieRent.Dtos
{
    public class CustomerDto
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        
        public string Name { get; set; }
  
        public MembershipTypeDto MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        //[AgeValidation]
        public DateTime? BirthDate { get; set; }
        

        public string SecondName { get; set; }

       
        public string Address { get; set; }
       

        public int Phone { get; set; }

      
        public string Email { get; set; }
    }
}