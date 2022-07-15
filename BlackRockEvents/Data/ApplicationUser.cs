using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlackRockEvents.Data
{
   /*Customizing the IdentityUser by adding additional columns to the AspNetUser table via inheritance.*/
   public class ApplicationUser:IdentityUser
   {
      [PersonalData]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [RegularExpression(@"^(\s*[A-Za-z]*)*$$")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [PersonalData]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [RegularExpression(@"^(\s*[A-Za-z]*)*$$")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [PersonalData]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [PersonalData]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [RegularExpression(@"^(\s*[A-Za-z]*)*$")]
        [Display(Name = "City")]
        public string City { get; set; }
        [PersonalData]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [RegularExpression(@"^(\s*[A-Za-z]*)*$")]
        [Display(Name = "State")]
        public string State { get; set; }
        [PersonalData]
        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }
        [PersonalData]
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
