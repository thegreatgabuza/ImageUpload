using ImageUpload.Data;
using ImageUpload.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImageUpload.Controllers
{
    [Authorize] // Protect this controller with authorization; only logged-in users can access it.
    public class ImageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImageController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(ImageUploadViewModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    var user = await _context.ApplicationUsers.SingleOrDefaultAsync(u => u.UserName == User.Identity.Name);
                    if (user != null && user.Credits > 0)
                    {
                        var userImage = new UserImage
                        {
                            UserId = user.Id,
                            ImageUrl = "path/to/your/image/storage", // Save the image to a location and store the path here.
                            UploadDate = DateTime.Now
                        };

                        _context.UserImages.Add(userImage);
                        user.Credits--; // Deduct one credit.
                        await _context.SaveChangesAsync();

                        return RedirectToAction("Index", "Home"); // Redirect to the home page after successful upload.
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Insufficient credits.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Please select a valid image file.");
                }
            }

            return View(model);
        }
    }
}
