using Microsoft.AspNetCore.Identity;

namespace QuickServe.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}