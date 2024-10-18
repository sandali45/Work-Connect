using System.ComponentModel.DataAnnotations;

namespace Work_Connect.Models
{
    public class JobApplication
    {
        [Key]
        public int ApplicationId { get; set; }

        public int JobID { get; set; }

        public string ApplicantName { get; set; }

        public string Resume { get; set; }

        public string UserID { get; set; } // Add UserID field

    }
}
