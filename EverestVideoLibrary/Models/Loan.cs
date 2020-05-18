using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EverestVideoLibrary.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime IssuedDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
        public string FineAmount { get; set; }
        public int MemberId { get; set; }
        public int DVDDetailsId { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Members { get; set; }
        [ForeignKey("DVDDetailsId")]
        public virtual DVDDetails DVDs { get; set; }
    }
}