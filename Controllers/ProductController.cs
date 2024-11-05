using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MPE.Models;
using MPE.Repository;

namespace MPE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  

    public class ProductController : ControllerBase
    {

        private IProduct product;
        public ProductController(IProduct product)
        {

            this.product = product;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Writer,Reader")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var p = await product.GetByIdAsync(id);

            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);

        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            var p = await product.GetByNameAsync(name);

            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);

        }

        [HttpPut]
        [Route("Update/{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Product p)
        {

            var updatedProduct = await product.UpdateAsync(p, id);

            if (updatedProduct != null)
            {
                return Ok(updatedProduct);
            }

            return BadRequest();

        }

        [HttpPost]
        [Route("Create")]


        public async Task<IActionResult> CreateProduct([FromBody] Product p)
        {
            var CreatedProduct = await product.CreateAsync(p);

            if (CreatedProduct != null) {

                return Ok(CreatedProduct);

            }

            return BadRequest();
        }
        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
             var deletedProduct= await product.DeleteAsync(id);

            if (deletedProduct != null) 
                {

                    return Ok(deletedProduct);
                }

                return BadRequest();  
        }
    }
    
}
