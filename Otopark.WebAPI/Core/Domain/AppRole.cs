namespace Otopark.WebAPI.Core.Domain
{
    public class AppRole
    {
        public int Id { get; set; }
        public String?  Defination { get; set; }

        public List<AppUser> AppUsers { get; set; }

        public AppRole()
        {
            AppUsers = new List<AppUser>();
        }

    }
}
