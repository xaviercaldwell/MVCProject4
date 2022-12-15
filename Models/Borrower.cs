using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Project4.Models
{
    public class Borrower
    {
        public int BorrowerID { get; set; }
        [Required(ErrorMessage = "enter a First Name")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        [Required(ErrorMessage = "enter a Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "enter a Phone Number")]
        [Phone(ErrorMessage = "enter a Phone Number")]
        [MaxLength(10, ErrorMessage = "Maximum 10 numbers")]
        public string PhoneNumber { get; set; }

        public string Slug =>
         LastName?.Replace(' ', '-').ToLower() + '-' + FirstName?.ToLower();
    }
}
