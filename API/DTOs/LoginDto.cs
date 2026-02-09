using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    // DTO used ONLY at the API boundary for authentication.
    // It represents the data required to attempt a login.
    //
    // This is NOT a domain model and should never contain logic.
    public class LoginDto
    {
        // Username is required to identify the user attempting to log in.
        // Validation happens automatically before the controller executes.
        [Required]
        public string Username { get; set; } = string.Empty;

        // Password is required to verify the user's identity.
        // This value is never stored, only checked.
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
