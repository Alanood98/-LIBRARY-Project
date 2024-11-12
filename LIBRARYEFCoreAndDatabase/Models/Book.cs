using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARYEFCoreAndDatabase.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BID { get; set; }

        [Required]
        public string Bname { get; set; }

        [Required]
        public string Bauthor { get; set; }

        [Required]
        public int BorrowedCopies { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Range(7, 14)]
        public int Period { get; set; }
        public int BorrTotalCopy { get; set; }


        //[ForeignKey("user")]
        //public int UID { get; set; }
        //public User user { get; set; }


        [ForeignKey("category")]
        public int CID { get; set; }
        public Category category { get; set; }

        public virtual ICollection<BorrowingBook> BorrowingBooks { get; set; }
    }
}
