using MediatR;

namespace Otopark.WebAPI.Core.Application.Features.CQRS.Commands
{
    public class UpdateProductCommandRequest:IRequest
    {
        public int Id { get; set; }
        public string? ParkSlot { get; set; }

        public bool? IsFull { get; set; }
    }
}
