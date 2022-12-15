using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project4.Models
{
    public class DiskHasBorrowerViewModel
    {
        public int BorrowedDiskID { get; set; }
        public int BorrowerID { get; set; }
        public int DiskID { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public virtual Borrower Borrower { get; set; }
        public virtual Disk Disk { get; set; }

        public List<Borrower> Borrowers { get; set; }
        public List<Disk> Disks { get; set; }
    }
}
