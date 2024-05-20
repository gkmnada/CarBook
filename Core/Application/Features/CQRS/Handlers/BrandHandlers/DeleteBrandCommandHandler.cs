using Application.Features.CQRS.Commands.BrandCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class DeleteBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public DeleteBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBrandCommand deleteBrandCommand)
        {
            var values = await _repository.GetAsync(deleteBrandCommand.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
