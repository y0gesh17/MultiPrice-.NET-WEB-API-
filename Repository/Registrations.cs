using Microsoft.EntityFrameworkCore;
using MPE.Models;
using System.Runtime.CompilerServices;

namespace MPE.Repository
{
    public class Registrations:IRegistration
    {

        private readonly AppDbContext dbContext;
        private readonly ITokenRepository r1;

        public Registrations(AppDbContext dbContext,ITokenRepository r1)
        {
            this.dbContext = dbContext;
            this.r1 = r1;
        }


        //public async Task<RegisterModel> CreateAsync(RegisterModel walk)
        //{
        //    await dbContext.registerModel.AddAsync(walk);
        //    await dbContext.SaveChangesAsync();
        //    return walk;
        //}

        public async Task<RegisterModel> CheckAsync(UserData u)
        {
            //var ans = await dbContext.registerModel.FromSqlRaw(@"Select * from RegisterModel where Email={0} ", u.Email).SingleOrDefaultAsync();

            // if(ans==null )
            //{
            //    return null;
            //}
            //if(u.Password!=ans.Password)
            //    {
            //    return null;
            //}
            //return ans;

            return null;
        }
    }
}
