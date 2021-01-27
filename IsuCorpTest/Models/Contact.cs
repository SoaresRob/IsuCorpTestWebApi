using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IsuCorpTest.Models
{
    public class Contact
    {
        [Key]
        public Int64 ContactId { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public string ContactName { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string BirthDate { get; set; }

        public ICollection<Reservation> Reservation { get; set; }
        public Int64 ContactTypeId { get; set; }

    }
}
