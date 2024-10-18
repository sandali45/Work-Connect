using System.ComponentModel.DataAnnotations;

namespace Work_Connect.Models
{
    public class JobApplication
    {
        [Key] // This annotation specifies that ApplicationId is the primary key
        public int ApplicationId { get; set; } // Primary key

        public int JobID { get; set; } // Foreign key for the associated job

        public string ApplicantName { get; set; } // Applicant's name

        public string Resume { get; set; } // Base64 or file path for the resume
    }
}
