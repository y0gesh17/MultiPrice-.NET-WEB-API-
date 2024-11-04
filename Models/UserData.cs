using Microsoft.AspNetCore.Identity;

namespace MPE.Models
{
    public class UserData
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Address { get ; set; }

        public int Pincode { get; set; }

        public IdentityUser User { get; set; }
    }
}
