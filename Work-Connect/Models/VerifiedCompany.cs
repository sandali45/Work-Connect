using System.ComponentModel.DataAnnotations;

namespace Work_Connect.Models
{
    public class VerifiedCompany
    {
        [Key]
        public int companyId { get; set; } // Primary key

        [Required]
        [StringLength(255)]
        public string companyName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string companyEmail { get; set; }

        [Required]
        [StringLength(100)]
        public string companyType { get; set; }

        [Required]
        [StringLength(255)]
        public string location { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Default to current time
    }
}
