using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Otopark.WebAPI.Core.Application.Features.CQRS.Commands;
using Otopark.WebAPI.Core.Application.Features.CQRS.Queries;
using Otopark.WebAPI.Infrastucture.Tools;
using System.IdentityModel.Tokens.Jwt;

namespace Otopark.WebAPI.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest registerUserCommandRequest)
        {
            await _mediator.Send(registerUserCommandRequest);
            return Created("", registerUserCommandRequest);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SigIn(CheckUserQueryRequest checkUserQueryRequest)
        {
            var user = await _mediator.Send(checkUserQueryRequest);
            if (user.IsExist)
            {
                var token =JwtTokenGenerator.GenerateToken(user);
                return Created("",token);
            }
            else
            {
                return BadRequest("Username or password Error!");
            }
        }

    }
}
