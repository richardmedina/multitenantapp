namespace MultiTenantApi.Models.Auth
{
    public class UserCredentialModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MfaCode { get; set; }
    }
}
