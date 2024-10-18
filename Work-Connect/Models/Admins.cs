namespace Work_Connect.Models
{
    public class Admins
    {
        public int Id { get; set; }  // Maps to Id column, primary key with identity
        public string Username { get; set; }  // Maps to Username column
        public string Password { get; set; }  // Maps to Password column
    }
}
