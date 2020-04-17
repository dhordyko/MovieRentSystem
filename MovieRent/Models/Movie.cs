using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MovieRent.Models
{
    public class Movie
    {
        public CultureInfo usEnglish = new CultureInfo("en-US");
        public int? Id { get; set; }
        [Required(ErrorMessage ="Wprowadz nazwę filmu")]
        [Display(Name ="Nazwa")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Wprowadz datę dd/mm/yyyy")]
        [Display(Name = "Data relizu")]
        public DateTime? ReleaseDate { get; set; }
        [Required(ErrorMessage = "Wprowadz datę dd/mm/yyyy")]
        [Display(Name = "Data posiadania")]
        public DateTime? AddedDate { get; set; }
        [Required(ErrorMessage = "Wprowadz ilość")]
        [Display(Name = "Ilość")]
        [Range(1,30, ErrorMessage = "Ilość musi być wprowadzona w zakresie od 1 do 30") ]
        public int StockNumber { get; set; }
        [Required(ErrorMessage = "Załoduj obrazek filmu")]
        [Display(Name = "Miniatura filmu")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Wprowadz tekst")]
        [Display(Name = "Tekst")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Wprowadz aktorów")]
        [Display(Name = "Aktorzy")]
        public string Actors { get; set; }
        public GenreType GenreType { get; set; }
      public Country Coutnry { get; set; }
        [Required(ErrorMessage = "Wprowadz imię reżysera")]
        [Display(Name = "Reżyseria")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Wprowadz długość filmu ")]
        [Display(Name = "Długość filmu")]
        public string Duration { get; set; }
        [Display(Name = "Kraj")]
        [Required(ErrorMessage = "Wybierz kraj")]
        public byte CountryId { get; set; }

        [Display(Name = "Gatunek")]
        [Required(ErrorMessage = "Wskaż gatunek")]
        public byte GenreTypeId { get; set; }
      
        public Movie() {
            this.ReleaseDate = null;
            this.AddedDate = null;
        }
        
    }
    
}