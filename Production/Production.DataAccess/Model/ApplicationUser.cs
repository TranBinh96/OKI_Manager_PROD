using Microsoft.AspNetCore.Identity;

namespace Production.DataAccess.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string Room { get; set; }
    }
}
