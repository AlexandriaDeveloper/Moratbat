using System.Text.Json.Serialization;

namespace Domain.IdentityModels
{
    public class AuthModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        //  public DateTime Expires { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
