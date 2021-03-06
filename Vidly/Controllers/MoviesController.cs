﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;


        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            else
                return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };

            return View("Movie", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => id == c.Id);

            if (movie == null)
                return HttpNotFound();
            else
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("Movie", viewModel);
            }
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
            }

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieDb.Name = movie.Name;
                movieDb.GenreId = movie.GenreId;
                movieDb.Added = movie.Added;
                movieDb.Released = movie.Released;
                movieDb.Stock = movie.Stock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}