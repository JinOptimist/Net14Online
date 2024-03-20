namespace ChatMiniService.Services
{
    public class AuthService
    {
        public const string AUTH_HEADER_NAME = "authsmile";

        public bool ValidateToken(string authTokern)
        {
            return authTokern == "123";
        }
    }
}
