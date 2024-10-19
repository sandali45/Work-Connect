using System.ComponentModel.DataAnnotations;

namespace Work_Connect.Models
{
    public class Usersappliedjob
    {
        [Key] // This attribute marks ApplicationId as the primary key
        public int ApplicationId { get; set; } // Primary key with auto-increment

        public int JobID { get; set; } // JobID provided manually

        [Required]
        [StringLength(100)]
        public string JobTitle { get; set; } // Job title

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; } // Company name

        [Required]
        [StringLength(100)]
        public string ApplicantName { get; set; } // Applicant's name

        public string Resume { get; set; } // Resume as a base64-encoded string
    
}
}
