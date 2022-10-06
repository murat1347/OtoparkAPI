using MediatR;
using Otopark.WebAPI.Core.Application.Features.CQRS.Commands;
using Otopark.WebAPI.Core.Application.Interfaces;
using Otopark.WebAPI.Core.Domain;

namespace Otopark.WebAPI.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updateEntity = await _repository.GetByIdAsync(request.Id);
            if(updateEntity is not null)
            {
                updateEntity.ParkSlot = request.ParkSlot;
                updateEntity.IsFull = request.IsFull;

                await _repository.UpdateAsync(updateEntity);
            }
            return Unit.Value;
        }
    }
}
