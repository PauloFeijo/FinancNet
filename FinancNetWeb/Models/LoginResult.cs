namespace FinancNetWeb.Models
{
    public class LoginResult
    {
        public string? Error { get; set; }
        public string? AccessToken { get; set; }
        public string? Expiration { get; set; }
    }
}
