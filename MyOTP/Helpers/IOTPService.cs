namespace MyOTP.Helpers
{
    public interface IOTPService
    {
        int GenerateOTP();
        bool ValidateOTP(int otp);
    }
}
