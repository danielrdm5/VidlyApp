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
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        private IMapper _iMapper;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieDto>()
                    .ForMember(m => m.Id, opt => opt.Ignore());
                cfg.CreateMap<MovieDto, Movie>()
                    .ForMember(m => m.Id, opt => opt.Ignore());
            });
            _iMapper = config.CreateMapper();
        }

        //Get /api/Movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(_iMapper.Map<Movie, MovieDto>);
        }


        //Get /api/Movies/1
        public IHttpActionResult GetMovie(int id)
        {
            MovieDto destination = new MovieDto();
            var Movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (Movie == null)
                return NotFound();

            destination = _iMapper.Map<Movie, MovieDto>(Movie);
            return Ok(destination);
        }


        //post /api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto MovieDto)
        {
            if (MovieDto ==null || !ModelState.IsValid)
                return BadRequest();

            var Movie = _iMapper.Map<MovieDto, Movie>(MovieDto);

            _context.Movies.Add(Movie);
            _context.SaveChanges();

            MovieDto.Id = Movie.Id;
            return Created(new Uri(Request.RequestUri + "" + Movie.Id), MovieDto);
        }

        //PUT /api/Movies/api
        [HttpPut]
        public void UpdateMovie(int id, MovieDto MovieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var MovieDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (MovieDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _iMapper.Map<MovieDto, Movie>(MovieDto, MovieDb);

            _context.SaveChanges();
        }

        //Delete /api/Movies/1
        public void DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var MovieDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (MovieDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(MovieDb);
            _context.SaveChanges();
        }

    }
}
