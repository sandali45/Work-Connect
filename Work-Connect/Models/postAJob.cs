using System.ComponentModel.DataAnnotations;

namespace Work_Connect.Models
{
    public class postAJob
    {
        [Key]
        public int JobId { get; set; }

        [Required]
        [StringLength(255)]
        public string JobTitle { get; set; }

        [Required]
        [StringLength(255)]
        public string CompanyName { get; set; }

        [Required]
        public string JobDescription { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid minimum salary")]
        public decimal MinSalary { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid maximum salary")]
        public decimal MaxSalary { get; set; }

        [StringLength(255)]
        public string? JobCategory { get; set; } // This could store comma-separated values for multiple categories.

        [StringLength(255)]
        public string? JobType { get; set; } // This could store comma-separated values for multiple job types.

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Automatically set when the job is created
    }
}
