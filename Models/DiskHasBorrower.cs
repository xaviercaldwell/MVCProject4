using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project4.Models
{
    public class DiskHasBorrower
    {
        [Key]
        public int BorrowedDiskID { get; set; }
        public int BorrowerID { get; set; }
        

        public int DiskID { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public virtual Borrower Borrower { get; set; }
        
        public virtual Disk Disk { get; set; }
    }
}
