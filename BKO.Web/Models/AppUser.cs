using Microsoft.AspNetCore.Identity;

namespace BKO.Web.Models
{
    public class AppUser : IdentityUser
    {
        // Extended Properties
        public long? FacebookId { get; set; }
        public string PictureUrl { get; set; }
    }
}