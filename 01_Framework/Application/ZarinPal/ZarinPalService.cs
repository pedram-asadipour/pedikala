using System.Globalization;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Serialization.Json;

namespace _01_Framework.Application.ZarinPal
{
    public class ZarinPalService : IZarinPalService
    {
        public string Prefix { get; set; }
        public string SiteUrl { get; set; }
        private string MerchantId { get;}

        public ZarinPalService(IConfiguration configuration)
        {
            Prefix = configuration.GetSection("payment")["method"];
            SiteUrl = configuration.GetSection("payment")["siteUrl"];
            MerchantId = configuration.GetSection("payment")["merchant"];
        }

        public PaymentResponse PaymentRequest(double amount, string mobile, string email, string description,
             long orderId)
        {
            var client = new RestClient($"https://{Prefix}.zarinpal.com/pg/rest/WebGate/PaymentRequest.json");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new PaymentRequest
            {
                Mobile = mobile,
                CallbackURL = $"{SiteUrl}/Checkout?handler=CallBack&orderId={orderId}",
                Description = description,
                Email = email,
                Amount = int.Parse(amount.ToString(CultureInfo.InvariantCulture)),
                MerchantID = MerchantId
            });

            var response = client.Execute(request);
            var jsonSerializer = new JsonSerializer();
            return jsonSerializer.Deserialize<PaymentResponse>(response);
        }

        public VerificationResponse VerificationRequest(string authority, double amount)
        {
            var client = new RestClient($"https://{Prefix}.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new VerificationRequest
            {
                Amount = int.Parse(amount.ToString(CultureInfo.InvariantCulture)),
                MerchantID = MerchantId,
                Authority = authority
            });

            var response = client.Execute(request);
            var jsonSerializer = new JsonSerializer();
            return jsonSerializer.Deserialize<VerificationResponse>(response);
        }
    }
}