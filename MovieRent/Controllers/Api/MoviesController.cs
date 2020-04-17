using AutoMapper;
using MovieRent.Dtos;
using MovieRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.IO;
using System.Web;

namespace MovieRent.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.Include(m=>m.GenreType).ToList().Select(Mapper.Map<Movie,MovieDto>);
        }
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();
            return Ok( Mapper.Map<Movie,MovieDto>(movie));
        }
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto )
        {
            if (!ModelState.IsValid)
                return NotFound();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            
           // var fileName = Path.GetFileName(file.FileName);
           // string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
            //string myfile = name + "_" + movie.Id; //appending the name with id  
            //// store the file inside ~/project folder(Img)  
            //var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Img"), myfile);
           // movie.Image = path;
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }
        [HttpPut]
        public void UpdateMovie(MovieDto movie)
        {
            if (!ModelState.IsValid)
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());
            var md = Mapper.Map<MovieDto, Movie>(movie);
           var movieinDb = _context.Movies.SingleOrDefault(c => c.Id == md.Id);
            if (movieinDb == null)
             throw new HttpResponseException(HttpStatusCode.NotFound);
            movieinDb.Name = md.Name;
            movieinDb.AddedDate = md.AddedDate;
            movieinDb.ReleaseDate = md.ReleaseDate;
            movieinDb.StockNumber = md.StockNumber;
            movieinDb.GenreTypeId = md.GenreTypeId;

            _context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieinDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieinDb);
            _context.SaveChanges();

        }
    }
}
