using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsuCorpTestData.Models
{
    public class ReservationDTO
    {
        [Key]
        public Int64 RevervationId { get; set; }
        public string ReservationDetails { get; set; }
        public Int64 ContactId { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public Int64 ContactTypeId { get; set; }
        public string ContactTypeName { get; set; }
    }
}
