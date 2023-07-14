namespace MyOTP.Services
{
    public interface IEmailService
    {
        void SendOTPByEmail(string email, int otp);
    }
}
