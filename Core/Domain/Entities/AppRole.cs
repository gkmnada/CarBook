namespace Domain.Entities
{
    public class AppRole
    {
        public int AppRoleID { get; set; }
        public string RoleName { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
