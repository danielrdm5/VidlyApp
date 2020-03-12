using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.App_Start;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto : AutoMapperBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Put a Name")]
        [StringLength(255)]
        public string Name { get; set; }


        public bool IsSusbcribedToNewsLetter { get; set; }


        public byte MembershipTypeId { get; set; }


        [Min18YearsMember]
        public DateTime? BirthDay { get; set; }
    }
}