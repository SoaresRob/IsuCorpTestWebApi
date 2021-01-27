using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsuCorpTest.Models
{
    public class ContactType
    {
        [Key]
        public Int64 ContactTypeId { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public string ContactTypeName { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}