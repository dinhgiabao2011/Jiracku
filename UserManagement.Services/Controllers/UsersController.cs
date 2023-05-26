using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.Services.DBContext;
using UserManagement.Services.Models;

namespace UserManagement.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var listUser = _context.Users.ToList();
            return Ok(listUser);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var newUser = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Salt = user.Salt,
                Password = user.Password,
                Avatar = user.Avatar,
                RefreshToken = user.RefreshToken
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return Ok(newUser);
        }
    }
}
