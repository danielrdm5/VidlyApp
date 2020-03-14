using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;
        private IMapper _iMapper;
        public RentalsController()
        {

            _context = new ApplicationDbContext();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Rental, RentalDto>();
                cfg.CreateMap<RentalDto, Rental>()
                    .ForMember(m => m.Id, opt => opt.Ignore());
            });
            _iMapper = config.CreateMapper();
        }



        // api/rentals
        [HttpPost]
        public IHttpActionResult Create(RentalDto rentalDto)
        {
            if (rentalDto.MovieIds.Count == 0)
                return BadRequest("No Movies have been given.");

            var customer = _context.Customers.SingleOrDefault(
                c => c.Id == rentalDto.CustomerId);

            if (customer == null)
                return BadRequest("Customer not found");

            var movies = _context.Movies.Where(
                m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != rentalDto.MovieIds.Count)
                return BadRequest("One or more movies are Invalid.");


            foreach (var movie in movies)
            {
                if (movie.Available == 0)
                    return BadRequest("Movie is not available.");

                movie.Available--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
