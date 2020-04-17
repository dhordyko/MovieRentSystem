using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieRent.Models;
namespace MovieRent.Dtos
{
    public class MovieDto
    {
        public int? Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime? ReleaseDate { get; set; }
        
        public DateTime? AddedDate { get; set; }
        
        public int StockNumber { get; set;  }
        public string Image { get; set; }
        public string Text { get; set; }
       
       public GenreTypeDto GenreType { get; set; }


        public byte GenreTypeId { get; set; }
    }
}