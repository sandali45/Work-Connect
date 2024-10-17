using System.Security.Cryptography;
using System.Text;

namespace Work_Connect.Helpers
{
    public static class PasswordHelper
    {
        // Method to hash the password
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        // Method to verify if a provided password matches the hashed password in the database
        public static bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            var enteredHashedPassword = HashPassword(enteredPassword); // Hash the entered password
            return enteredHashedPassword == storedHashedPassword; // Compare the hashed entered password with the stored one
        }
    }
}
