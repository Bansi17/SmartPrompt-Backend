namespace ECommerce_Backend.Services
{
    public class JWTSettings
    {

        public string Key {  get; set; }    

        public string Issuer {  get; set; }

        public string Audience { get; set; }

        public int ExpiryDuration { get; set; }
    }
}
