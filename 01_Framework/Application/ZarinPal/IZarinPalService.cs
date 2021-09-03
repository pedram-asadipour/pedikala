namespace _01_Framework.Application.ZarinPal
{
    public interface IZarinPalService
    {
        PaymentResponse PaymentRequest(double amount, string mobile, string email, string description,
            long orderId);

        VerificationResponse VerificationRequest(string authority, double price);
    }
}