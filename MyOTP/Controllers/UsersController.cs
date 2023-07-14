// UsersController
using Microsoft.AspNetCore.Mvc;
using MyOTP.Models;
using MyOTP.Repositories;
using MyOTP.Services;

namespace MyOTP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }
    }
}
