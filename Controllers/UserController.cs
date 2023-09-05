using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ELK.Models;

namespace ELK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        List<User> users = new List<User>()
        {
             new User { Id = 1, Name = "Ahmed" },
             new User { Id = 2, Name = "Hassan" },
             new User { Id = 3, Name = "Hossam" },
             new User { Id = 4, Name = "Kareem" },
             new User { Id = 5, Name = "Makkah" },
             new User { Id = 5, Name = "Kenzi" }
        };

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                var message = $"User found with ID: {id}\n" +
                                     $"User Name is: {user.Name}";
                _logger.LogInformation(message);
                return Ok(message);
            }
            var notFoundMessage = $"No User was found with such ID: {id}";
            _logger.LogWarning(notFoundMessage);
            return NotFound(notFoundMessage);
        }
    }
}
