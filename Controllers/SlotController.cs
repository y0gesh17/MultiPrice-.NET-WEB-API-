using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace MPE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {

        [HttpGet]
        [Authorize (AuthenticationSchemes="Bearer",Roles="Reader")]

          public async Task<IActionResult> GetAllSlot()
        {
              
        }

    }
}
