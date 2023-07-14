// SignupController
using Microsoft.AspNetCore.Mvc;
using MyOTP.Models;
using MyOTP.Repositories;
using MyOTP.Services;

namespace MyOTP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignupController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public SignupController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] SignupRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // SignupRequest'ten User nesnesi oluştur
            var newUser = new User
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                Phone = request.Phone
            };

            // UserRepository'ye kullanıcıyı ekle
            _userRepository.Add(newUser);

            return Ok(newUser);
        }
    }
}
