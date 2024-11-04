using Microsoft.AspNetCore.Identity;
using MPE.Models;

namespace MPE.Repository
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<String> s);
    }
}
