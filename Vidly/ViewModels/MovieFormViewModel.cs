using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int? GenreId { get; set; }

        [Required]
        public DateTime? Added { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Must be between 1 to 20")]
        public int? Stock { get; set; }

        [Required]
        public DateTime? Released { get; set; }


        public IEnumerable<Genre>  Genres { get; set; }

        public string Title
        {
            get { return Id != 0 ? "Edit Movie" : "New movie"; }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            Released = movie.Released;
            Stock = movie.Stock;
            GenreId = movie.GenreId;
        }
    }
}