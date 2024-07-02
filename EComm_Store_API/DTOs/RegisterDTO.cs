using System.ComponentModel.DataAnnotations;

namespace EComm_Store_API.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string DisplayName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", ErrorMessage = "Password must contain at least 1 Small-Case letter, 1 Capital letter, 1 Digit, 1 Special Character and the length should be between 6-10 characters.")]
        public string Password { get; set; }
    }
}