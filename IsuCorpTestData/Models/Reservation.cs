using System;
using System.ComponentModel.DataAnnotations;

namespace IsuCorpTestData.Models
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