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

        public PostController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                var post = new Post
                {
                    Content = model.Content,
                    CreatedAt = DateTime.UtcNow,
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
