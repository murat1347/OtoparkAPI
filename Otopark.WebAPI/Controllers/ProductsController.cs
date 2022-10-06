using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Otopark.WebAPI.Core.Application.Features.CQRS.Commands;
using Otopark.WebAPI.Core.Application.Features.CQRS.Queries;
using Otopark.WebAPI.Core.Features.CQRS.Queries;

namespace Otopark.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllProductsQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetProductQueryRequest(id));

            return result == null ? NotFound() : Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        { 
            var result = await _mediator.Send(new DeleteProductCommandRequest(id));

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateProductCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }






    }
}
