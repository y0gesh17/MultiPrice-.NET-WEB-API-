using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MPE.Models;
using MPE.Repository;


namespace MPE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        ISlot s;
        public SlotController(ISlot s)
        {
            this.s = s; 
            
        }

        [HttpGet]
        [Authorize (AuthenticationSchemes="Bearer",Roles="Reader,Writer")]

          public async Task<IActionResult> GetAllSlot()
        {
             var s1= await s.GetAllSlotAsync();

            return Ok(s1);
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid  Id)
        {

            var slot = await  s.GetSlotByIdAsync(Id);

            if(slot==null)
            {
                return BadRequest("Slot Not Exist");
            }

            return Ok(slot);

        }

        [HttpPost]
        [Route("Update/{id:Guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Writer")]

        public async Task<IActionResult> UpdateSlot([FromBody] Slot slots, [FromRoute] Guid Id)
        {

          var slot=  await s.UpdateSlotAsync(slots,Id);


            if(slot!=null)
            {
                return Ok(slot);
            }

            return BadRequest("Slot Not Found");

        }
        [HttpDelete]
        [Route("Delete")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Writer")]
        public async  Task<IActionResult> DeleteSlot([FromRoute] Guid Id)
        {
           var slot= await s.DeleteSlotAsync(Id);

            if(slot!=null)
            {
                return Ok(slot);
            }

            return BadRequest("Slot Not Found");
        }

        [HttpPost]
        [Route("Create")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Writer")]

        public async Task<IActionResult> CreateSlot([FromBody] Slot slot)
        {
            var slt = await s.CreateSlotAsync(slot);

            return Ok(slot);


        }


    }
}
