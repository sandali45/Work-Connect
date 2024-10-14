namespace Work_Connect.Models
{
    public class Job
    {
        public int Id { get; set; } // Add an Id property for primary key
        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? Skills { get; set; }
        public string? PaymentDetails { get; set; }
    }
}
