using Microsoft.AspNetCore.Identity;

namespace CondoLounge.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ICollection<Condo> condos { get; set; } = new List<Condo>();
        
    }
}
