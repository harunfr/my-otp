using Microsoft.AspNetCore.Mvc;
using MyOTP.Helpers;
using MyOTP.Models;
using MyOTP.Repositories;
using MyOTP.Services;

namespace MyOTP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        private readonly IOTPService _otpService;

        public LoginController(IUserRepository userRepository, IEmailService emailService, IOTPService otpService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _otpService = otpService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest request)
        {
            var user = _userRepository.GetUserByUsername(request.Username);
            if (user == null)
            {
                return BadRequest("Geçersiz e-posta adresi");
            }

            var otp = _otpService.GenerateOTP();

            _emailService.SendOTPByEmail(user.Email, otp);

            var response = new
            {
                Message = "E-posta ile OTP gönderildi",
                userId = user.Id
            };

            return Ok(response);
        }

        [HttpPost("verify")]
        public IActionResult VerifyOTP([FromBody] OTPVerificationRequest request)
        {
            var user = _userRepository.GetById(request.Id);
            if (user == null)
            {
                return BadRequest("Geçersiz e-posta adresi");
            }

            bool isOTPValid = _otpService.ValidateOTP(request.OTP);

            if (isOTPValid)
            {
                var response = new
                {
                    Message = "OTP doğrulandı"
                };
                return Ok(response);
            }
            else
            {
                return BadRequest("Geçersiz OTP");
            }
        }
    }
}
