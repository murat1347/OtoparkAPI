﻿using MediatR;

namespace Otopark.WebAPI.Core.Application.Features.CQRS.Commands
{
    public class RegisterUserCommandRequest: IRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }

    }
}
