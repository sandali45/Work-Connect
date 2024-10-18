using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Work_Connect.Models
{
    public class VerifiedUsers
    {
        [Key]
     
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incrementing primary key
        public int Id { get; set; } // Primary key, auto-incrementing integer

        [Required]
        public int UserID { get; set; } // Manually added User ID

        [Required]
        [StringLength(100)]
        public string UserName { get; set; } // User's name (max 100 characters)

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string UserEmail { get; set; } // User's email (must be unique)

        [StringLength(15)]
        public string TelephoneNumber { get; set; } // User's telephone number (optional)
        public int? CompanyID { get; set; } // Foreign key reference to the company (optional)
    }

    
}
