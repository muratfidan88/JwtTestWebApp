namespace JwtTestWebApp.JwtApi.Data.Entities
{
    public class AppRole
    {
        public int Id { get; set; }
        public string Defination { get; set; } = string.Empty;
        public List<AppUser>? AppUsers { get; set; }
        
    }
}
