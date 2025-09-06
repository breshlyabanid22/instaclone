using InstagramClone.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: User/Profile/{username}

        public async Task<IActionResult> Profile(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            //Find the user by username including their posts
            var user = await _context.Users
                .Include(u => u.Posts)
                .FirstOrDefaultAsync(u => u.Username == id);

            if(user == null)
            {
                return NotFound();
            }

            //Order posts by creation date, most recent first
            user.Posts = user.Posts?.OrderByDescending(p => p.TimeStamp).ToList();

            return View(user);
        }

    }
}
