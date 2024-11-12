using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARYEFCoreAndDatabase.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UID { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be exactly 8 characters long.")]
        [MaxLength(8, ErrorMessage = "Password must be exactly 8 characters long.")]
        [RegularExpression(@"^(?=.*[A-Z])[A-Za-z\d]{8}$", ErrorMessage = "Password must be 8 characters long and contain at least one uppercase letter.")]
    
        public int Upassword { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]

        public string Uname { get; set; }

       

        public enum gender
        {
            F , M
        }
        public gender Ugender { get; set; }


        //[ForeignKey("book")]
        //public int BID { get; set; }
        //public Book book { get; set; }

        public virtual ICollection<BorrowingBook> BorrowingBooks { get; set; }

    }
}
