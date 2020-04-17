using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MovieRent.Models;
using MovieRent.Dtos;

namespace MovieRent.App_Start
{
    public class MapperProfile: Profile
    {
         public MapperProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<GenreType, GenreTypeDto>();
            Mapper.CreateMap<OrdersDto, Orders>();
            Mapper.CreateMap<Orders, OrdersDto>();
        }
    }
}