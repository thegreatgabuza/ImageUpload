using System.ComponentModel.DataAnnotations;

namespace ImageUpload.Models
{
    public class ImageUploadViewModel
        {
            [Required(ErrorMessage = "Please select an image.")]
            [Display(Name = "Image")]
            public IFormFile ImageFile { get; set; }

            [Display(Name = "Description (optional)")]
            public string Description { get; set; }
        }
    }

