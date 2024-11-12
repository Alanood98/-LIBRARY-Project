using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARYEFCoreAndDatabase.Models
{
    [PrimaryKey(nameof(BID), nameof(UID))]
    public class BorrowingBook
    {
       
       
        
        [ForeignKey("book")]
        public int BID { get; set; }
        public virtual Book book { get; set; }




        [ForeignKey("user")]
        public int UID { get; set; }
        public virtual User user { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

       

        [Required]
        
        public DateOnly BRdate { get; set; }

        [Required]
        public DateOnly predictDate { get; set; }

        [Required]
        public DateOnly ActualDate { get; set; }

        [Required]
        public bool IsReturen { get; set;}



    }
}
