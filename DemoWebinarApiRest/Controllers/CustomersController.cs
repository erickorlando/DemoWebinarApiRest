using System.Threading.Tasks;
using Dto.Request;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace DemoWebinarApiRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.ListAsync());
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> Get(int id)
        {
            var response = await _service.GetByIdAsync(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}/Directions")]
        public async Task<IActionResult> GetDirections(int id)
        {
            return Ok(await _service.GetDirectionsAsync(id));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DtoCustomerRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _service.CreateAsync(request);

            return Created($"/{response}", new
            {
                Id = response
            });
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put(int id, DtoCustomerRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _service.UpdateAsync(id, request);

            return Accepted(new
            {
                Id = response
            });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Accepted(new
            {
                Id = id
            });
        }
    }
}