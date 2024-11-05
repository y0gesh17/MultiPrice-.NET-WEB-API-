using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MPE.Models;
using MPE.Repository;

namespace MPE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketController : ControllerBase
    {
        IBucket b;
        public BucketController(IBucket b)
        {
            this.b = b;
        }
        ISlot s;
      
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Reader,Writer")]

        public async Task<IActionResult> GetAllBucket()
        {
            var s1 = await b.GetAllBucket();

            return Ok(s1);
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {

            var bt = await b.GetBucketById(Id);

            if (bt == null)
            {
                return BadRequest("Bucket Not Exist");
            }

            return Ok(bt);

        }

        [HttpPost]
        [Route("Update/{id:Guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Writer")]

        public async Task<IActionResult> UpdateBucket([FromBody] Bucket bucket, [FromRoute] Guid Id)
        {

            var bt = await b.UpdateBucket(bucket, Id);


            if (bt != null)
            {
                return Ok(bt);
            }

            return BadRequest("Bucket Not Found");

        }
        [HttpDelete]
        [Route("Delete")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Writer")]
        public async Task<IActionResult> Deleteucket([FromRoute] Guid Id)
        {
            var bt = await b.DeleteBucket(Id);

            if (bt != null)
            {
                return Ok(bt);
            }

            return BadRequest("Bucket Not Found");
        }

        [HttpPost]
        [Route("Create")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Writer")]

        public async Task<IActionResult> CreateBucket([FromBody] Bucket bucket)
        {
            var bt = await b.CreateBucket(bucket);

            return Ok(bt);


        }


    }


}

