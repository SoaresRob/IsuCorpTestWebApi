using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IsuCorpTest.Models
{
    public class Reservation
    {
        [Key]
        public Int64 RevervationId { get; set; }
        [Required]
        public string ReservationDetails { get; set; }
        public Int64 ContactId { get; set; }
    }
}