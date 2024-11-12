using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARYEFCoreAndDatabase.Models
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Aname { get; set; }

        [Required]
        [Range(8, 12)]
        public int Apassword { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string AEmail { get; set; }
    }
}
