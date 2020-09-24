namespace Inseego.Repositories.ServiceClient.Model
{
    public class LocalisationTokenModel
    {
        public string Token { get; set; }
        public string ApplicationUrl { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class LocalisationTokenModelNew
    {
        public string JwtToken { get; set; }
        public string DisplayName { get; set; }
        public string TenantId { get; set; }
        public bool IsUserExistOnFirebase { get; set; }
        public string UserId { get; set; }
        public string SubscriptionKey { get; set; }
        public string Status { get; set; }
    }
}
