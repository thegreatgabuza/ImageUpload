using System.ComponentModel.DataAnnotations;

namespace ImageUpload.Models
{
    public class ApplicationUser
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        // Add more user properties as needed, e.g., Name, PasswordHash, etc.

        [Required]
        public int Credits { get; set; } // Number of credits the user has.

        // Navigation property for uploaded images.
        public ICollection<UserImage> UploadedImages { get; set; }
    
}
    
}
