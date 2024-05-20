using Application.Features.CQRS.Commands.BrandCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand updateBrandCommand)
        {
            var values = await _repository.GetAsync(updateBrandCommand.BrandID);
            values.BrandName = updateBrandCommand.BrandName;
            await _repository.UpdateAsync(values);
        }
    }
}
