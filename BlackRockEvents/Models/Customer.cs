using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackRockEvents.Models
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^(\s*[A-Za-z]*)*$$")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^(\s*[A-Za-z]*)*$")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^(\s*[A-Za-z]*)*$")]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^(\s*[A-Za-z]*)*$")]
        public string State { get; set; }
        [Required]
        [RegularExpression(@"^\d{5}(?:[- ]?\d{4})?$")]
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }

        List<Reservation> Reservations { get; set; }
        
    }
}
