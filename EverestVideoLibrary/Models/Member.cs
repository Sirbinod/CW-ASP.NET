using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EverestVideoLibrary.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
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
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        public int MemberCategoryId { get; set; }
        [ForeignKey("MemberCategoryId")]
        public virtual MemberCategory MemberCategorys { get; set; }
        public virtual IEnumerable<Loan> Loans { get; set; }
    }
}