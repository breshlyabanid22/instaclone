using InstagramClone.Data;
using InstagramClone.Models;
using InstagramClone.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostController(ApplicationDbContext context, UserManager<User> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var user = await _userManager.GetUserAsync(User);
                if(user == null)
                {
                    return Unauthorized();
                }

                var imageFile = model.ImageFile;
                string? imageUrl = null;
                if(imageFile != null && imageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    using(var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                    imageUrl = "/uploads/" + uniqueFileName;
                }

                var post = new Post
                {
                    Content = model.Content,
                    CreatedAt = DateTime.UtcNow,
                    ImageUrl = imageUrl,
                    UserId = user.Id
                };

                 _context.Posts.Add(post);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Post created successfully!";

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
