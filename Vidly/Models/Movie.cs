using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Genre Genre { get; set; }
        [Required]
        public int GenreId { get; set; }

        [Required] 
        public DateTime Added { get; set; }
        [Required]
        public int Stock { get; set; }
        public DateTime Released { get; set; }


    }
}