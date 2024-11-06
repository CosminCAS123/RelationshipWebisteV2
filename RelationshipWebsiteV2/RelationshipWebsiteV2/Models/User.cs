


namespace RelationshipWebsiteV2.Models
{
    public class User
    {
        public string UserId { get; set; } // Unique ID for the user
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } // Hashed password for security
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; } // Account creation date
        public DateTime LastLoginDate { get; set; }

        public string Bio { get; set; } // Short bio about the user
        public string PartnerId { get; set; } // ID of their partner, if connected
        public bool IsVerified { get; set; } // Email or account verification status
    }
}
