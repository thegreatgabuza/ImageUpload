using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImageUpload.Models
{
    public class UserImage 
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; } // Foreign key to link the image to a user.

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } // Navigation property to the user who uploaded the image.

        [Required]
        public string ImageUrl { get; set; } // URL or file path of the uploaded image.

        [Required]
        public DateTime UploadDate { get; set; } // Date and time when the image was uploaded.
    
}
}
