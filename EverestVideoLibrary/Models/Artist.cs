using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EverestVideoLibrary.Models
{
    public class Artist
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [NotMapped]
        public HttpPostedFile Image { get; set; }
        public string ImagePath { get; set; }
        //navigation properties
        public virtual IEnumerable<DVDDetails> DVDs { get; set; }


    }
}