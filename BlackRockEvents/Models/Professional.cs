using System.ComponentModel.DataAnnotations;

namespace BlackRockEvents.Models
{
    public class Professional
    {
        [Key]
        public int Professional_Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name must be less than 50 letters.")]
        [RegularExpression(@"^(\s*[A-Za-z]*)*$$", ErrorMessage = "First name cannot contain digits or special characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name must be less than 50 letters.")]
        [RegularExpression(@"^(\s*[A-Za-z]*)*$$", ErrorMessage = "Last name cannot contain digits or special characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name must be less than 50 letters.")]
        [RegularExpression(@"^(\s*[A-Za-z]*)*$$", ErrorMessage = "Profession name cannot contain digits or special characters.")]
        [Display(Name = "Profession")]
        public string ProfessionName { get; set; }
        [Display(Name = "Image Name")]
        [DataType(DataType.ImageUrl)]
        public string PhotoName { get; set; }
        [Required]
        [EmailAddress]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email Address. ")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Invalid Phone Number. Format: 555-555-5555")]
        [Phone]
        public string Phone { get; set; }
    }
}
