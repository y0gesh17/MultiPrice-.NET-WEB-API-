using MPE.Models;

namespace MPE.Repository
{
    public interface IRegistration
    {

      // Task<RegisterModel> CreateAsync(RegisterModel walk);
        
       Task<RegisterModel> CheckAsync(UserData u);
    }
}
