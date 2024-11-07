




using Microsoft.EntityFrameworkCore;

namespace RelationshipWebsiteV2.Models
{
    [PrimaryKey("UserId")]
    public class User
    {
        
        public int UserId { get; set; } // Unique ID for the user
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } // Hashed password for security
        public DateOnly DateOfBirth { get; set; }
        public DateOnly CreatedDate { get; set; } // Account creation date
      

        public string? Bio { get; set; } // Short bio about the user
        public string? PartnerId { get; set; } // ID of their partner, if connected
        public bool? IsVerified { get; set; } // Email or account verification status
    }
}
