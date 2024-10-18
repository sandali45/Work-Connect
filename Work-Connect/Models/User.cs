namespace Work_Connect.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Nullable new fields
        public string? Occupation { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? Experience { get; set; }
        public string? Education { get; set; }
        public string? Skills { get; set; }
    }

}
