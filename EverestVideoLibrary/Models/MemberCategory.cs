using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EverestVideoLibrary.Models
{
    public class MemberCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public string TotalLoan { get; set; }
        public string ReturningDays { get; set; }
        public virtual IEnumerable<Member> Members { get; set; }
    }
}