using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project4.Models
{
    public class Disk
    {

       

        public int DiskID { get; set; }

        [Required(ErrorMessage = "enter a Name")]
        public string DiskName { get; set; }

        [Required(ErrorMessage = "enter a date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Select a Status")]
        public int? StatusID { get; set; }

        [Required(ErrorMessage = "Select a Genre")]

        public int? GenreID { get; set; }

        [Required(ErrorMessage = "Select a Disktype")]

        public int? DiskTypeID { get; set; }


        public virtual Genre Genre { get; set; }

        public virtual DiskType DiskType { get; set; }

        public virtual Status Status { get; set; }

        

        public string Slug => DiskName?.ToLower();


    }
}
