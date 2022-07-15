using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackRockEvents.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Event Start Time:")]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "Event End Time:")]
        public DateTime EndTime { get; set; }
        [Required]
        [Display(Name = "Event Type:")]
        public EventType EventType { get; set; }
        [Range(1,200, ErrorMessage = "Maximum Occupancy is 200.")]
        [Display(Name ="Number of Attendees:")]
        public int NumOfAttendees { get; set; }
        [Required]
        [Display(Name = "Guests Per Table:")]
        [Range(0,20, ErrorMessage="Must be between 0 and 20 guests per table. Zero indicating that no tables are needed.")]
        public int SeatsPerTable { get; set; }  
        [Required]
        public Boolean IsApproved { get; set; }

        [ForeignKey("Customer")]
        public int? Customer_id { get; set; }
        [NotMapped]
        public Customer Customer { get; set; }
        
    }
}
