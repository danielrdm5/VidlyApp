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

        [Required]
        public string Name { get; set; }

        
        
        public Genre Genre { get; set; }
        
        [Required]
        public int GenreId { get; set; }

        [Required] 
        public DateTime Added { get; set; }
        
        [Required]
        [Range(1, 20, ErrorMessage = "Must be between 1 to 20")]
        public int Stock { get; set; }

        [Required]
        public DateTime Released { get; set; }


        public byte Available { get; set; }

    }
}