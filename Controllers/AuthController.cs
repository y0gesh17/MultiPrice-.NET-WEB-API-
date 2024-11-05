//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace MPE.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {

//        public AuthController()
//        {

//        }
//    }
//}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MPE.Models;
using MPE.Repository;
using NZWalks.API.Repositories;
using System.Data;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private IRegistration r;
    private ITokenRepository t;
    private UserManager<IdentityUser> usermanager;
    public AuthController(IRegistration r, ITokenRepository t, UserManager<IdentityUser> usermanager)
    {
        this.r = r;
        this.t = t;
        this.usermanager = usermanager;
    }

    [HttpPost("register")]
    
    public async Task<IActionResult> Register([FromBody] RegisterDto m)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid registration request.");
        var model = new RegisterModel
        {
            Username = m.firstname,
            password = m.password,
            email = m.email,
            ConfirmPassword = m.password,
            Role = m.role

        };
        if (model.password != model.ConfirmPassword)
            return BadRequest("Passwords do not match.");

        var identityUser = new IdentityUser
        {

            UserName = model.email,
            Email = model.email
        }; 

        var identityResult = await usermanager.CreateAsync(identityUser, model.password);

        if (identityResult.Succeeded)
        {
            if (model.Role != null && model.Role.Length > 0)
            {

                identityResult = await usermanager.AddToRolesAsync(identityUser, model.Role);

                if (identityResult.Succeeded)
                {
                    return Ok("User Register!! Please Login");


                }
                return BadRequest("Something Went Wrong ");
            }
        }

        return BadRequest("Some thing went wrong ");

        // Check if a user with the same username or email already exists
        //var userExists = await _userManager.FindByNameAsync(model.Username) != null ||
        //                 await _userManager.FindByEmailAsync(model.Email) != null;

        //if (userExists)
        //    return BadRequest("A user with the same username or email already exists.");

        // Create a new ApplicationUser instance
        //var user = new ApplicationUser
        //{
        //    UserName = model.Username,
        //    Email = model.Email
        //};

        // Create the user with the provided password
        

       
    }


    //[HttpPost]
    //[Route("Login")]
    //public async Task<IActionResult> LoginUser([FromBody] RegisterModel user)
    //{

    //    //var  Email = user.Email;
    //    //var Password = user.Password;


    //    //var a = await r.CheckAsync(user);
    //    //if(a!=null)
    //    //{
    //    //    var jwtToken = t.CreateJWTToken(user);

    //    //    return Ok(jwtToken);
    //    //}

    //    //  return BadRequest("Invalid user or Password");

    //    var user1 = await usermanager.FindByEmailAsync(user.Email);

    //    if (user1 != null)
    //    {
    //        var CheckPassword = await usermanager.CheckPasswordAsync(user1, user.Password);

    //        if (CheckPassword)
    //        {
    //            var roles = usermanager.GetRolesAsync(user1);
    //            var l=roles.ToList();
    //            if (roles != null)
    //            {
    //                var jwt = t.CreateJWTToken(user1, );
    //            }
    //        }

    //    }
        //private IActionResult BadRequest(object errors)
        //{
        //    throw new NotImplementedException();
        //}
    //}
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginDTO user)
    {
        // Find user by email
        var identityUser = await usermanager.FindByEmailAsync(user.email);

        if (identityUser != null)
        {
            // Check if the provided password is correct
            var passwordValid = await usermanager.CheckPasswordAsync(identityUser, user.password);

            if (passwordValid)
            {
                // Retrieve roles and generate JWT token
                var roles = await usermanager.GetRolesAsync(identityUser);

                if (roles != null)
                {
                    var jwtToken = t.CreateJWTToken(identityUser, roles.ToList());

                    var jwt = new LoginJWT
                    {
                        JWTToken = jwtToken,

                    };
                    return Ok(jwt);
                }
            }
        }

        return BadRequest("Invalid user or password.");
    }
}
