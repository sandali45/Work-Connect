using System.ComponentModel.DataAnnotations;

namespace Work_Connect.Models
{
    public class InterviewSchedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string ApplicantName { get; set; }

        [Required]
        public string Message { get; set; }

    
        
    }
}
