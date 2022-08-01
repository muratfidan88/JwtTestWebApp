namespace JwtTestWebApp.JwtApi.Data.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public AppRole? AppRole { get; set; }
        
    }
}
