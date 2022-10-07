using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Otopark.WebAPI.Core.Application.Features.CQRS.Queries;

namespace Otopark.WebAPI.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Members")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetCategoriesQueryRequest());

            return Ok(result);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProducts(int id)
        {
            var data = await _mediator.Send(new GetProductWithCategoryQueriesRequest(id));

            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);
        }
    }
}
