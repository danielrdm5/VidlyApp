using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public GenreDto Genre { get; set; }

        public int GenreId { get; set; }
        public DateTime Added { get; set; }

        public int Stock { get; set; }

        public DateTime Released { get; set; }
    }
}