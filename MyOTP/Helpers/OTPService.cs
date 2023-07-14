using System;

namespace MyOTP.Helpers
{
    public class OTPService : IOTPService
    {
        public int GenerateOTP()
        {
            // Geçici çözüm
            var random = new Random();
            return random.Next(100000, 999999);
        }

        public bool ValidateOTP(int otp)
        {
            // Deneme amaçlı test
            return otp == 123456;
        }
    }
}
