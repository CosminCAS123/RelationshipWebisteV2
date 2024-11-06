using System.Security.Cryptography;
using System.Text;

namespace RelationshipWebsiteV2.Services
{
    public static class HashPasswordService
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower(); // Convert to hex string
            }
        }

        public static bool CompareHashes(string hash1, string hash2) => string.Equals(hash1, hash2);
        

    }
}
