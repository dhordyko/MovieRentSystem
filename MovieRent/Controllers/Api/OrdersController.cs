using AutoMapper;
using MovieRent.Dtos;
using MovieRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Http;

namespace MovieRent.Controllers.Api
{
    public class OrdersController : ApiController
    {
        private ApplicationDbContext _context;
        
        public OrdersController()
        {
            _context = new ApplicationDbContext();
            
           
        }
   
        public IEnumerable<OrdersDto> GetCustomers()
        {
           var x= _context.Orders.Include(c => c.Customer).ToList().Select(Mapper.Map<Orders, OrdersDto>);
          
                    var pingresult = from p in x
                           group p by p.OrderNmb into g
                             select g.OrderByDescending(t => t.Name).FirstOrDefault();
            return pingresult;


        }
       

        

        [System.Web.Http.HttpDelete]
        public void DeleteOrder(string id)
        {
            var orderinDb = _context.Orders.Where(c => c.OrderNmb == id).ToList();
           foreach(var i in orderinDb)
            {
                _context.Orders.Remove(i);
            }
            _context.SaveChanges();

        }

       
    }
}
