namespace JwtTestWebApp.JwtApi.Tools.Jwt
{
    public class JwtTokenResponse
    {
        public string Token { get; set; }

        public JwtTokenResponse(string token)
        {
            Token = token;
        }
    }
}
