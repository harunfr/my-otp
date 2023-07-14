using System;
using System.Net;
using System.Net.Mail;

namespace MyOTP.Services
{
    public class EmailService : IEmailService
    {
        public void SendOTPByEmail(string email, int otp)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress("your-email@example.com");
            mail.To.Add(email);
            mail.Subject = "OTP Doğrulama Kodu";
            mail.Body = $"OTP Doğrulama Kodunuz: {otp}";

            // E-posta gönderme işlemini gerçekleştir
            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("harunguven35@gmail.com", "fhkshvjzfybqtlqa");
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);
            }

            // OTP kodunun geçerlilik süresini belirle
            TimeSpan validityDuration = TimeSpan.FromHours(1);
            DateTime otpExpiration = DateTime.Now.Add(validityDuration);

            ExpireOTP(otpExpiration);
        }

        private void ExpireOTP(DateTime expirationTime)
        {
            // OTP kodunu belirtilen süre sonunda geçersiz yap
        }
    }
}
