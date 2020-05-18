using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EverestVideoLibrary.Models
{
    public class DVDDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int Length { get; set; }
        [NotMapped]
        public HttpPostedFile CoverImage { get; set; }
        public string CoverImagePath { get; set; }

        public virtual IEnumerable<Artist> Artists { get; set; }
        public virtual IEnumerable<Producer> Producers { get; set; }
        public virtual IEnumerable<Loan> Loans { get; set; }
    }
}