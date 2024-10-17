using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work_Connect.Models
{
    [Table("waitingJob")]
    public class WaitingJob
    {
        [Key] 
        public int JobId { get; set; } 

        [Required]
        [MaxLength(255)]
        public string JobTitle { get; set; } 

        [Required]
        [MaxLength(255)]
        public string CompanyName { get; set; } 

        [Required]
        public string JobDescription { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal MinSalary { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal MaxSalary { get; set; } 

        [MaxLength(255)]
        public string JobCategory { get; set; } 

        [MaxLength(255)]
        public string JobType { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
