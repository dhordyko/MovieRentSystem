using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRent.Models
{
    public class Orders
    {   [Key]
        public int OrdersId { get; set; }
        public int? MovieId { get; set; }
        public string Name { get; set; }
        public string AbonementType { get; set; }
        public Customer Customer { get; set; }
        public int? CustomerId { get; set; } 
       public double Cena { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNmb { get; set; }
        [Required(ErrorMessage = "Wybierz datę odebrania")]
        public string PickUpDate { get; set; }

     
        public string RentPeriod { get; set; }

        public string DeliveryMode { get; set; }
      
      

    }
}